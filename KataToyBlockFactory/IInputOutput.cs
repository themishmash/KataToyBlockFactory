using System;

namespace KataToyBlockFactory
{
    public interface IInputOutput
    {
        string AskQuestion(string question);

        DateTime AskDate(string question);

        void output(string message);
    }
}