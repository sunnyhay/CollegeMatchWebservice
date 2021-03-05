using CollegeMatchWebservice.Models;

namespace CollegeMatchWebservice.Util
{
    public static class Utils
    {
        public static UserInput ParseUserInput(Input input)
        {
            return new UserInput
            {
                Gpa = double.Parse(input.Gpa),
                Sat = new SatInput
                {
                    Avg = int.Parse(input.SatAvg),
                    Read = int.Parse(input.SatRead),
                    Math = int.Parse(input.SatMath),
                    Wrt = int.Parse(input.SatWrt)
                },
                Act = new ActInput
                {
                    Cum = int.Parse(input.ActCum),
                    Eng = int.Parse(input.ActEng),
                    Math = int.Parse(input.ActMath),
                    Wrt = int.Parse(input.ActWrt)
                },
                Rank = int.Parse(input.Rank)
            };
        }
    }
}
