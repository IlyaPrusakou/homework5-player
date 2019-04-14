using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audioplayer
{
    class Player
    {
        private int volume;
        public const int minVolume = 0;
        public const int maxVolume = 100;
        public bool isLock;
        private bool playing;
        public Song[] songs;
        //B5-Player4/10. Properties.
        public bool Playing
        {
            get
            {
                return playing;
            }
        }
        
        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (value < minVolume)
                {
                    volume = minVolume;
                }
                else if (value > maxVolume)
                {
                    volume = maxVolume;
                }
                else
                {
                    volume = value;
                }
            }

        }
        //B5-Player8/10. ParamsParameters
        public void ParametrSong(params Song[] SongList)
        {
            foreach (Song item in SongList)
            {
                Console.WriteLine(item.title);
            }
        }
        //B5-Player3/10. Method. 
        public void VolumeUp()
        {
            Volume = Volume + 1;
            Console.WriteLine("Volume " + Volume);

        }

        public void VolumeDown()
        {
            Volume = Volume - 1;
            Console.WriteLine("Volume " + Volume);
        }
        public void VolumeChange(int Step, string op)
        {
            if (op == "+")
            {
                Console.WriteLine($"up volume {Step}");
                Volume = Volume + Step;
            }
            else if (op == "-")
            {
                Console.WriteLine($"down volume {Step}");
                Volume = Volume - Step;
            }
        }
        public void Play()
        {
            Console.WriteLine("islock " + isLock);
            Console.WriteLine("playing " + playing);
            if (playing == true)
            {
                Console.WriteLine("to Play has started");
                for (int i = 0; i < songs.Length; i++)
                {
                    Console.WriteLine(songs[i].title);
                    System.Threading.Thread.Sleep(2000);
                }
            }

        }
        public bool Stop()
        {
            if (isLock == false)
            {
                Console.WriteLine("Stop");
                playing = false;
            }

            return playing;
        }
        public bool Start()
        {
            if (isLock == false)
            {
                Console.WriteLine("Start");
                playing = true;
            }

            return playing;
        }
        public void Pause()
        {
        }
        public void Lock()
        {
            Console.WriteLine("Player is locked");
            Console.WriteLine("Before action " + isLock);
            isLock = true;
            Console.WriteLine("After action " + isLock);
        }
        public void UnLock()
        {
            Console.WriteLine("Player is unlocked");
            Console.WriteLine("Before action " + isLock);
            isLock = false;
            Console.WriteLine("After action " + isLock);
        }
        public void Load()
        {
        }
        public void Save()
        {
        }

    }
}