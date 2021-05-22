class Solution {
    public int findNumbers(int[] nums) {
        int res = 0;
        for(int i = 0; i < nums.length; i++) {
            if(this.digitsNumber(nums[i]) % 2 == 0) {
                res++;
            }
        }
        return res;
    }
    
    private int digitsNumber(int n) {
        int res = 0;
        while(n > 0) {
            res++;
            n /= 10;
        }
        return res;
    }
}
