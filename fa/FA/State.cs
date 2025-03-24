namespace fans;

public class State(string Name, bool IsAcceptState)
{
    public string Name = Name;
    public bool IsAcceptState = IsAcceptState;
    public Dictionary<char, State> Transitions = new Dictionary<char, State>();
}