// https://leetcode.com/explore/learn/card/fun-with-arrays/521/introduction/3238/

class Solution {
    public int findMaxConsecutiveOnes(int[] nums) {
        int res = 0;
        int max = 0;

        for(int i = 0; i < nums.length; i++) {
            if(nums[i] == 1) {
                res += 1;
            } else {
                if(res > max) {
                    max = res;
                }
                res = 0;
            }
        }

        return res > max ? res : max;
    }
}
