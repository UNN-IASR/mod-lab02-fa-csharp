namespace fa.Code
{
    public class FA2 : Fa4States
    {
        protected override void InitTransitions()
        {
            A.Transitions['0'] = C;
            A.Transitions['1'] = B;
            B.Transitions['0'] = D;
            B.Transitions['1'] = A;
            C.Transitions['0'] = A;
            C.Transitions['1'] = D;
            D.Transitions['0'] = B;
            D.Transitions['1'] = C;
        }
    }
}