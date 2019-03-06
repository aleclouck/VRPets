using System;

namespace PetManager
{
    public class Mood
    {
        Random rand = new Random();

        public enum MoodList
        {
            Neutral, 
            Happy,
            Sad,
            Frightened,
            Angry
        };

        private MoodList state;

        public Mood()
        {
            state = MoodList.Neutral;
        }

        public MoodList State
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

        // Set a random mood from enum list.
        public void ChangeMood()
        {
            int randomMood = rand.Next(Enum.GetNames(typeof(MoodList)).Length);
            state = (MoodList)randomMood;
        }
    }
}
