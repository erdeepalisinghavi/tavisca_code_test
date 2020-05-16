using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
        private readonly List<Frame> _frames;

        public Game()
        {
            _frames = new List<Frame>();
        }

        public void CreateFrame(int firstRollPinDownCount)
        {
            _frames.Add(new Frame(firstRollPinDownCount));
        }

        public void CreateFrame(int firstRollPinDownCount, int secondRollPinDownCount)
        {
            _frames.Add(new Frame(firstRollPinDownCount, secondRollPinDownCount));
        }

        public void CreateFrame(int firstRollPinDownCount, int secondRollPinDownCount, int extraRollPinDownCount)
        {
            _frames.Add(new Frame(firstRollPinDownCount, secondRollPinDownCount, extraRollPinDownCount));
        }

        public int GetScore()
        {
            RecalculateFrameScore();
            var frameScores = _frames.Select(i => i.frameScore).ToList();
            return (frameScores.Sum());
        }

        private void RecalculateFrameScore()
        {
            for (int i = 0; i < _frames.Count-1; i++)
            {
                if (_frames[i].IsStrike)
                {
                    if (_frames[i + 1].IsLastFrame)
                        _frames[i].frameScore = _frames[i].frameScore + _frames[i + 1].firstRollPinDownValue + _frames[i + 1].secondRollPinDownValue;
                    else if (_frames[i + 1].IsStrike)
                        _frames[i].frameScore = _frames[i].frameScore + _frames[i + 1].frameScore + _frames[i + 2].firstRollPinDownValue;
                    else
                        _frames[i].frameScore = _frames[i].frameScore + _frames[i + 1].frameScore;
                }
                else if (_frames[i].IsSpare)
                {
                    _frames[i].frameScore = _frames[i].frameScore + _frames[i + 1].firstRollPinDownValue;
                }
            }
        }
    }
}
