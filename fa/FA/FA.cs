namespace fans;

public abstract class FA
{
    public State? InitialState;

    public bool? Run(IEnumerable<char> str)
    {
        if (InitialState == null) return null;

        State current = InitialState;
        foreach (char ch in str)
        {
            current = current.Transitions[ch];
            if (current == null) return null;
        }
        return current.IsAcceptState;
    }
}