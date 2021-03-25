// Task: Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
 var twoSum = function(nums, target) {
    if(!nums && !nums.length) {
        return []
    }
    
    for(let i = 0; i < nums.length; i++) {
        const n = target - nums[i];
        for(let j = i + 1; j < nums.length; j++) {
            if(nums[j] === n) {
                return [i, j]
            }
        }
    }
    
    return []
};
