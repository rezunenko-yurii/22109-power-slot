using System;
using System.Collections.Generic;
using SlotsGame.Scripts.Slot;
using Zenject;

namespace SlotsGame.Scripts.Lines
{
    public class LinesManager
    {
        [Inject] private Config _config;

        public Action<int> CountChanged;
        private int _lineNumber;
        public Line[] Lines { get; private set; }  

        public int Count
        {
            get => _lineNumber;
            set
            {
                _lineNumber = value;
                ChangeActiveLines();
                CountChanged?.Invoke(_lineNumber);
            }
        }

        private int _activeLinesAmount = 0;
        public int GetActiveLinesAmount()
        {
            _activeLinesAmount = 0;
            foreach (var line in Lines)
            {
                if (line.IsActive)
                {
                    _activeLinesAmount++;
                }
            }

            return _activeLinesAmount;
        }

        public List<Line> GetActiveLines()
        {
            var lines = new List<Line>();
            foreach (var line in Lines)
            {
                if (line.IsActive)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }

        private void ChangeActiveLines()
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                if (i <= _lineNumber)
                {
                    Lines[i].IsActive = true;
                }
                else
                {
                    Lines[i].IsActive = false;
                }
            }
        }

        public  void Prepare()
        {
            Lines = new Line[_config.linesBlueprints.items.Length];
            for (int i = 0; i < _config.linesBlueprints.items.Length; i++)
            {
                LineBlueprint blueprint = _config.linesBlueprints.items[i];
                Lines[i] = new Line(blueprint);
            }
        }
        
        public void Clear() { }
    }
}