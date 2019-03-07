using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;


public class VoiceDetection : MonoBehaviour {
    private KeywordRecognizer activeListening;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private Jump jumping;

    private void Start() {
        jumping = GetComponent<Jump>();

        actions.Add("jump", Jump);

        activeListening = new KeywordRecognizer(actions.Keys.ToArray());
        activeListening.OnPhraseRecognized += RecognizedVoice;
        activeListening.Start();
    }

    private void RecognizedVoice(PhraseRecognizedEventArgs voice) {
        Debug.Log(voice.text);
        actions[voice.text].Invoke();
    }

    public void Jump() {
        jumping.DoJump();
    }
}
