using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

namespace VoiceDetection {

    public class SpeechToText : MonoBehaviour {
        private KeywordRecognizer treeLayer1;
        private List<string> layer1Keys = new List<string>();
        private Dictionary<string, bool> keywordActive = new Dictionary<string, bool>();

        // Start is called before the first frame update
        void Start() {
            treeLayer1 = new KeywordRecognizer(layer1Keys.ToArray());
            treeLayer1.OnPhraseRecognized += VoiceRecognized;
            treeLayer1.Start();
        }

        // LateUpdate is called once per frame after all updates
        void LateUpdate() {
            foreach(string key in layer1Keys) {
                keywordActive[key] = false;
            }
        }

        //called when a keyword is recognized by voice detection
        private void VoiceRecognized(PhraseRecognizedEventArgs voice) {
            Debug.Log(voice.text);
            keywordActive[voice.text] = true;
        }

        //allows the addition of words into the list of keywords.
        public void AddWord(string word) {
            layer1Keys.Add(word);
            keywordActive.Add(word, false);
        }

        //main function used for checking if a word was heard
        public bool Hears(string word) {
            return keywordActive[word];
        }
    }
}
