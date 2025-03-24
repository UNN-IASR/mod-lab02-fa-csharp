namespace fans;

public class State(string Name, bool IsAcceptState, Dictionary<char, State> Transitions)
{
    public string Name = Name;
    public bool IsAcceptState = IsAcceptState;
    public Dictionary<char, State> Transitions = Transitions;
}