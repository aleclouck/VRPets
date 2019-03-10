using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

namespace VoiceDetection {

    public class SpeechToText : MonoBehaviour {
        static private KeywordRecognizer treeLayer1;
        static private List<string> layer1Keys;
        static private Dictionary<string, bool> keywordActive = new Dictionary<string, bool>();

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

        private static void VoiceRecognized(PhraseRecognizedEventArgs voice) {
            Debug.Log(voice.text);
            keywordActive[voice.text] = true;
        }

        //allows the addition of words into the list of keywords.
        public static void AddWord(string word) {
            layer1Keys.Add(word);
            keywordActive.Add(word, false);
            treeLayer1.Stop();
            treeLayer1 = new KeywordRecognizer(layer1Keys.ToArray());       //there must be a better way***
            treeLayer1.OnPhraseRecognized += VoiceRecognized;
            treeLayer1.Start();
        }

        //main function used for checking if a word was heard
        public static bool Hears(string word) {
            return keywordActive[word];
        }
    }
}
