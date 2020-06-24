using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Interpreter Pattern - Given a language we have to interpret the sentences in the language 
namespace DesignPatterns.Behavioral_Patterns
{
    public interface Exp
    {
        bool evaluate(string con);
    }
    public class Name : Exp
    {
        private string name;
        public Name(string name)
        {
            this.name = name;
        }
        public bool evaluate(string con)
        {
            return name.Contains(con);
        }
    }
    public class ORExpression : Exp
    {
        private Exp first;
        private Exp second;
        public ORExpression(Exp first,Exp second)
        {
            this.first = first;
            this.second = second;
        }
        public bool evaluate(string con)
        {
           return first.evaluate(con)  || second.evaluate(con);
        }
    }
    public class ANDExpression : Exp
    {
        private Exp first;
        private Exp second;
        public ANDExpression(Exp first, Exp second)
        {
            this.first = first;
            this.second = second;
        }
        public bool evaluate(string con)
        {
            return first.evaluate(con) && second.evaluate(con);
        }
    }

    class InterpreterClient
    {
        public static void Main(string[] args)
        {
            Exp person1=new Name("rajat,shoeb");
            Exp person2 = new Name("shoeb,hashir");
            Exp isFriend = new ORExpression(person1,person2);
            Console.WriteLine("rajat is a friend of Hashir :"+isFriend.evaluate("hashir"));
            Exp isFriendBoth = new ANDExpression(person1,person2);
            Console.WriteLine("shoeb is a friend of both rajat and Hashir :" + isFriend.evaluate("shoeb"));

            Console.ReadKey();
        }
    }
}
