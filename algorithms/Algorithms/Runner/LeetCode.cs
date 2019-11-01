namespace Runner
{
    public static class LeetCode
    {
        // TwoSum (https://leetcode.com/problems/two-sum/submissions/)
        public static int[] TwoSum(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] {i, j};
                    }
                }
            }

            return new[] {0, 0};
        }
        
        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock/submissions/
        public static int MaxProfit(int[] prices) {
            var maxDelta = 0;

            for(var i = 0; i < prices.Length; i++)
            {
                for(var j = i + 1; j < prices.Length; j++)
                {
                    if(prices[j] - prices[i] > maxDelta)
                    {
                        maxDelta = prices[j] - prices[i];
                    }    
                }
            }

            return maxDelta;
        }
    }
}
