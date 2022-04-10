namespace fa.Code
{
    public class FA1 : Fa4States
    {
        protected override void InitTransitions()
        {
            A.Transitions['0'] = C;
            A.Transitions['1'] = B;
            B.Transitions['0'] = D;
            B.Transitions['1'] = B;
            C.Transitions['0'] = State.EndState;
            C.Transitions['1'] = D;
            D.Transitions['0'] = State.EndState;
            D.Transitions['1'] = D;
        }
    }
}