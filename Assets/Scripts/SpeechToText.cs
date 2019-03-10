using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

namespace VoiceDetection {

    public class SpeechToText : MonoBehaviour {
        static private KeywordRecognizer treeLayer1;
        static private List<string> layer1Keys;
        static private Dictionary<string, bool> keywordActive;

        // Start is called before the first frame update
        void Start() {
            layer1Keys = new List<string>();

            keywordActive = new Dictionary<string, bool>();

            treeLayer1 = new KeywordRecognizer(layer1Keys.ToArray());
            treeLayer1.OnPhraseRecognized += VoiceRecognized;
            treeLayer1.Start();
        }

        // Update is called once per frame
        void LateUpdate() {
            foreach(string key in layer1Keys) {
                keywordActive[key] = false;
            }
        }

        private void VoiceRecognized(PhraseRecognizedEventArgs voice) {
            Debug.Log(voice.text);
            keywordActive[voice.text] = true;
        }

        //allows the addition of words into the list of keywords.
        public void AddWord(string word) {
            layer1Keys.Add(word);
            keywordActive.Add(word, false);
            treeLayer1 = new KeywordRecognizer(layer1Keys.ToArray());
            treeLayer1.OnPhraseRecognized += VoiceRecognized;
            treeLayer1.Start();
        }

        //main function used for checking if a word was heard
        public bool Hears(string word) {
            return keywordActive[word];
        }
    }
}
