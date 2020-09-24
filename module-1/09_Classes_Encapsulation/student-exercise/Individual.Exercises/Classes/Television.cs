namespace Individual.Exercises.Classes
{
    public class Television
    {
        public bool IsOn { get; private set; } = false;
        public int CurrentChannel { get; private set; } = 3;
        public int CurrentVolume { get; private set; } = 2;

        public void TurnOff()
        {
            IsOn = false;
        }

        public void TurnOn()
        {
            IsOn = true;
        }

        public void ChangeChannel(int newChannel)
        {
            if (IsOn && newChannel >= 3 && newChannel <= 18)
            {
                CurrentChannel = newChannel;

            }
        }

        public void ChannelUp()
        {
            if (IsOn && CurrentChannel < 18)
            {
                CurrentChannel++;
            } else if (IsOn && CurrentChannel == 18)
            {
                CurrentChannel = 3;
            }
        }

        public void ChannelDown()
        {
            if (IsOn && CurrentChannel > 3)
            {
                CurrentChannel--;
            } else if (IsOn && CurrentChannel == 3)
            {
                CurrentChannel = 18;
            }
        }

        public void RaiseVolume()
        {
            if (IsOn && CurrentVolume < 10)
            {
                CurrentVolume++;
            }
        }

        public void LowerVolume()
        {
            if (IsOn && CurrentVolume > 0)
            {
                CurrentVolume--;
            }
        }
    }
}
