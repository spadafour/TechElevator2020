namespace Lecture.Farming
{
    /// <summary>
    /// A base farm animal class.
    /// </summary>
    public abstract class FarmAnimal : ISingable
    {
        /// <summary>
        /// The farm animal's name.
        /// </summary>
        public string Name { get; }
        private bool isAsleep { get; set; }

        private string sound;
        /// <summary>
        /// The farm animal's sound.
        /// </summary>
        public  string Sound
        {
            get
            {
                if(isAsleep)
                {
                    return "Zzzzzz";
                }
                return sound;
            }
            set
            {
                sound = value;
            }
        }
        public bool Sleep()
        {
            isAsleep = true;
            return isAsleep;
        }

        public abstract string Eat();

        /// <summary>
        /// Creates a new farm animal.
        /// </summary>
        /// <param name="name">The name which the animal goes by.</param>
        /// <param name="sound">The sound that the animal makes.</param>
        public FarmAnimal(string name, string sound)
        {
            Name = name;
            Sound = sound;
        }
    }
}
