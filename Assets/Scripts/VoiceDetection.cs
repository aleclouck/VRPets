using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

namespace VoiceDetection {


    public class SpeechToText {
        private KeywordRecognizer treeRootWords;            //keyword recognizer for primary tree root
        private List<string> keyWords;                      //array of keywords
                                                            //sets each keyword as active or inactive
        private Dictionary<string, bool> wordHeard = new Dictionary<string, bool>();
        
        private void Start() {
            
            treeRootWords = new KeywordRecognizer(keyWords.ToArray());          //initialize the root words to be heard
            treeRootWords.OnPhraseRecognized += RecognizedVoice;                //set the event of being heard to call RecognizedVoice
            treeRootWords.Start();                                              //start the listening of root words
        }

        private void Update() {
            //set each  keyword to inactive
            foreach(string word in keyWords) {
                wordHeard[word] = false;
            }
        }

        //called when a word is recognized. word sent to debug and keyword set to active
        private void RecognizedVoice(PhraseRecognizedEventArgs voice) {
            Debug.Log(voice.text);
            wordHeard[voice.text] = true;
        }

        //allows the addition of words into the list of keywords.
        public void AddWord(string word) {
            keyWords.Add(word);
            wordHeard.Add(word, false);
        }

        //main function used for checking if a word was heard
        public bool Hears(string word) {
            return this.wordHeard[word];
        }
    }
}