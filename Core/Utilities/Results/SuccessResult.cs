

namespace Core.Utilities.Results
{
    public class SuccessResult : Result //true yu default verdiğimiz sınıf
    {
        //basenin mesajlı true olan consructurunu dön
        public SuccessResult(string message):base(true,message)
        {

        }

        //basenin mesajsız true olan consructurunu dön
        public SuccessResult() : base(true)
        {

        }
    }
}
