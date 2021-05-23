// https://leetcode.com/explore/learn/card/fun-with-arrays/521/introduction/3240/

class Solution {
    public int[] sortedSquares(int[] nums) {
        int[] res = new int[nums.length];

        int ir = nums.length - 1;
        int b = 0;
        int e = nums.length - 1;

        
        while (b <= e) {
            int sb = nums[b] * nums[b];
            int se = nums[e] * nums[e];

            if (se > sb) {
                res[ir--] = se;
                e--;
            } else {
                res[ir--] = sb;
                b++;
            }
        }

        return res;
    }
}
