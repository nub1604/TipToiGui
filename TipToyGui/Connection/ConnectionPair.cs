using System;

namespace TipToyGui
{
    public class ConnectionPair
    {
        private readonly ConnectionPoint _Input;
        private readonly ConnectionPoint _OutPut;

        public ConnectionPair(ConnectionPoint input, ConnectionPoint outPut)
        {
            _Input = input ?? throw new ArgumentNullException(nameof(input));
            _OutPut = outPut ?? throw new ArgumentNullException(nameof(outPut));
        }
        public bool Visible { get; set; }

        public ConnectionPoint Input { get => _Input; }
        public ConnectionPoint Output { get => _OutPut; }
    }
}