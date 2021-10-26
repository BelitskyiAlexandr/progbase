using System;

class HumanException : Exception
{
    public Human args;
    public HumanException(Human args) : base()
    {
        this.args = args;
    }

    public override string Message => $"Error: {args.Name} has high level of sugar. {args.Name} can't drink juice.";
}