using System;

namespace KataToyBlockFactory
{
    public interface IInputOutput
    {
        string AskQuestion(string question);

        int AskBlockQuantity(string question);

        DateTime AskDate(string question);
    }
}