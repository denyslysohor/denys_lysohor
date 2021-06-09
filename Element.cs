namespace Visitor
{
    public abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }
    
    class Element1 : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitElement1(this);
        }
    }
    
    class Element2 : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitElement2(this);
        }
    }
}