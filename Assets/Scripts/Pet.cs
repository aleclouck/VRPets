using System;
namespace AssemblyCSharp
{
    public class Pet
    {
        private string name;
        private Mood mood;

        /*===============
        || CONSTRUCTOR ||
        ===============*/
        public Pet()
        {
            name = "Snargle";
            mood = new Mood();
        }

        /*==================
        || HELPER METHODS ||
        ==================*/
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Mood Mood
        {
            get
            {
                return mood;
            }
            set
            {
                mood = value;
            }
        }
    }
}
