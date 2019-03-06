using System;

namespace AssemblyCSharp
{
    public class Mood
    {
        Random rand = new Random();
        private string[] mood =
        {
            "neutral", 
            "happy",
            "sad",
            "frightened",
            "angry"
        };

        private string state;

        public Mood()
        {
            state = mood[0];
        }

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public void ChangeMood()
        {
            int randomMood = rand.Next(mood.Length);
            state = mood[randomMood];
        }
    }
}
