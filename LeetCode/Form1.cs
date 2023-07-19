namespace LeetCode
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[] numbers = new int[] { 4, 3, 3, 9, 3, 0, 9, 2, 8, 3 };
            var a = Trap(numbers);
            return;
        }
        //42.Trapping Rain Water
        public int Trap(int[] height)
        {
            int Total = 0;
            int Max = height.Max();
            int CurrentNum = 0;
            List<int> maxNumberIndices = new List<int>();
            for (int i = 0; i < height.Length; i++)
            {
                if (height[i] == Max)
                {
                    maxNumberIndices.Add(i);
                }
            }

            if (maxNumberIndices.Count == 1)
            {
                CurrentNum = height[0];
                for (int i = 0; i < maxNumberIndices[0]; i++)
                {
                    if (CurrentNum > height[i + 1])
                    {
                        Total += CurrentNum - height[i + 1];
                    }
                    else
                    {
                        CurrentNum = height[i + 1];

                    }
                }
                CurrentNum = height[height.Count() - 1];
                for (int i = height.Count() - 1; i > maxNumberIndices[0]; i--)
                {

                    if (CurrentNum > height[i - 1])
                    {
                        Total += CurrentNum - height[i - 1];
                    }
                    else
                    {
                        CurrentNum = height[i - 1];

                    }
                }

            }
            else
            {
                CurrentNum = height[0];
                for (int i = 0; i < maxNumberIndices[maxNumberIndices.Count() - 1]; i++)
                {
                    if (CurrentNum > height[i + 1])
                    {
                        Total += CurrentNum - height[i + 1];
                    }
                    else
                    {
                        CurrentNum = height[i + 1];

                    }
                }
                CurrentNum = height[height.Count() - 1];
                for (int i = height.Count() - 1; i < maxNumberIndices[maxNumberIndices.Count() - 1]; i--)
                {

                    if (CurrentNum > height[i - 1])
                    {
                        Total += CurrentNum - height[i - 1];
                    }
                    else
                    {
                        CurrentNum = height[i - 1];

                    }
                }
            }
            return Total;
        }

        //Roman to Integer
        public int RomanToInt(string s)
        {
            char[] mangChuoi = s.ToCharArray();
            string[] kyTu = mangChuoi.Select(c => c.ToString()).ToArray();
            int total = 0;
            for (int i = 0; i < kyTu.Length; i++)
            {
                if (kyTu[i] == "I")
                {
                    if ((i + 1) < kyTu.Length && kyTu[i + 1] == "V")
                    {
                        total += 4;
                        i += 1;
                    }
                    else if ((i + 1) < kyTu.Length && kyTu[i + 1] == "X")
                    {
                        total += 9;
                        i += 1;
                    }
                    else
                    {
                        total += 1;
                    }

                }
                else if (kyTu[i] == "V")
                {
                    total += 5;
                }
                else if (kyTu[i] == "X")
                {
                    if ((i + 1) < kyTu.Length && kyTu[i + 1] == "L")
                    {
                        total += 40;
                        i += 1;
                    }
                    else if ((i + 1) < kyTu.Length && kyTu[i + 1] == "C")
                    {
                        total += 90;
                        i += 1;
                    }
                    else
                    {
                        total += 10;
                    }
                }
                else if (kyTu[i] == "L")
                {
                    total += 50;
                }
                else if (kyTu[i] == "C")
                {
                    if ((i + 1) < kyTu.Length && kyTu[i + 1] == "M")
                    {
                        total += 900;
                        i += 1;
                    }
                    else
                    {
                        total += 100;
                    }
                }
                else if (kyTu[i] == "D")
                {
                    total += 500;
                }
                else if (kyTu[i] == "M")
                {
                    total += 1000;
                }

            }
            return total;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {

            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            string soa = "";
            string sob = "";
            double Total = 0;

            ListNode head = null;
            ListNode current = null;

            while (l1 != null)
            {
                list1.Add(l1.val);
                l1 = l1.next;
            }
            while (l2 != null)
            {
                list2.Add(l2.val);
                l2 = l2.next;
            }
            for (int i = list1.Count - 1; i >= 0; i--)
            {
                soa += list1[i].ToString();
            }
            for (int i = list2.Count - 1; i >= 0; i--)
            {
                sob += list2[i].ToString();
            }
            Total = double.Parse(soa) + double.Parse(sob);

            char[] mangChuoi = Total.ToString().ToCharArray();
            string[] kyTu = mangChuoi.Select(c => c.ToString()).ToArray();

            for (int i = kyTu.Length - 1; i >= 0; i--)
            {
                int num = int.Parse(kyTu[i].ToString());
                ListNode newNode = new ListNode(num);

                if (head == null)
                {
                    head = newNode;
                    current = newNode;
                }
                else
                {
                    current.next = newNode;
                    current = current.next;
                }
            }
            return head;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        //1. Two Sum
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[0] = i;
                        result[1] = j;
                        i = nums.Length;
                        break;
                    }
                }
            }
            return result;
        }
        //Letter Combinations of a Phone Number
        public IList<string> LetterCombinations(string digits)
        {
            List<string> combinations = new List<string>();
            if (string.IsNullOrEmpty(digits))
            {
                return combinations;
            }

            Backtrack(combinations, digits, "", 0);
            return combinations;
        }
        static Dictionary<char, string> phoneDigits = new Dictionary<char, string>()
            {
                {'2', "abc"},
                {'3', "def"},
                {'4', "ghi"},
                {'5', "jkl"},
                {'6', "mno"},
                {'7', "pqrs"},
                {'8', "tuv"},
                {'9', "wxyz"}
            };

        static void Backtrack(List<string> combinations, string digits, string currentCombination, int index)
        {
            if (index == digits.Length)
            {
                combinations.Add(currentCombination);
                return;
            }

            char digit = digits[index];
            string letters = phoneDigits[digit];
            foreach (char letter in letters)
            {
                Backtrack(combinations, digits, currentCombination + letter, index + 1);
            }
        }
        //4. Median of Two Sorted Arrays
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] merged = nums1.Concat(nums2).ToArray();
            Array.Sort(merged);

            if (merged.Length % 2 == 0)
            {
                int index = merged.Length / 2;

                double so1 = merged[index - 1];
                double so2 = merged[index];
                return (so1 + so2) / 2;
            }
            else
            {
                int index = merged.Length / 2;
                double result = (merged[index]);
                return result;
            }

        }
        //Regular Expression Matching
        public bool IsMatch(string s, string p)
        {
            if (s.Trim() == p.Trim())
            {
                return true;
            }
            else
            {
                if (s.Trim().Length == p.Trim().Length)
                {
                    bool check = false;
                    for (int i = 0; i < s.Trim().Length; i++)
                    {
                        char[] mangChuoi1 = s.ToCharArray();
                        string[] kyTu1 = mangChuoi1.Select(c => c.ToString()).ToArray();
                        char[] mangChuoi2 = p.ToCharArray();
                        string[] kyTu2 = mangChuoi2.Select(c => c.ToString()).ToArray();


                        if (kyTu1[i] == kyTu2[i] || kyTu2[i] == "*")
                        {
                            return check = true;
                        }
                        else if (kyTu1[i] == kyTu2[i] || kyTu2[i] == ".")
                        {
                            return check = true;
                        }
                        else return check = false;
                    }
                }
                else if (s.Trim().Length < p.Trim().Length)
                {
                    bool check = false;
                    for (int i = 0; i < p.Trim().Length; i++)
                    {
                        char[] mangChuoi1 = s.ToCharArray();
                        string[] kyTu1 = mangChuoi1.Select(c => c.ToString()).ToArray();
                        char[] mangChuoi2 = p.ToCharArray();
                        string[] kyTu2 = mangChuoi2.Select(c => c.ToString()).ToArray();
                        for (int j = 0; j < kyTu1.Length; j++)
                        {
                            if (kyTu2[i] == "*")
                            {
                                check = true;
                                break;
                            }
                            else
                            {
                                check = false;

                            }
                        }

                    }
                    return check;
                }
            }
            return false;
        }




    }
}