using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Frame
    {
        public int firstRollPinDownValue;
        public int secondRollPinDownValue;
        public int extraRollPinDownValue;
        public int frameScore;
        public bool IsSpare;
        public bool IsStrike;
        public bool IsLastFrame;

        public Frame(int firstRollPinDownCount)
        {
            firstRollPinDownValue = firstRollPinDownCount;
            frameScore = firstRollPinDownCount;
            if (firstRollPinDownValue == 10)
                IsStrike = true;
        }

        public Frame(int firstRollPinDownCount,int secondRollPinDownCount)
        {
           firstRollPinDownValue = firstRollPinDownCount;
           secondRollPinDownValue = secondRollPinDownCount;
            frameScore = firstRollPinDownValue + secondRollPinDownValue;
            if (frameScore == 10)
                IsSpare = true;
        }

        public Frame(int firstRollPinDownCount, int secondRollPinDownCount, int extraRollPinDownCount)
        {
            firstRollPinDownValue = firstRollPinDownCount;
            secondRollPinDownValue = secondRollPinDownCount;
            extraRollPinDownValue = extraRollPinDownCount;
            frameScore = firstRollPinDownValue + secondRollPinDownValue + extraRollPinDownValue;
            IsLastFrame = true;
        }
    }
}
