namespace LeetCode.QuestionDatabase
{
    public partial class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length + nums2.Length];
            int i = 0;
            int j = 0;
            int index = 0;
            while (i < nums1.Length || j < nums2.Length)
            {
                if (i == nums1.Length) { result[index++] = nums2[j++]; continue; }
                if (j == nums2.Length)
                {
                    result[index++] = nums1[i++];
                    continue;
                }

                if (nums1[i] > nums2[j])
                {
                    result[index++] = nums2[j++];
                }
                else
                {
                    result[index++] = nums1[i++];
                }
            }
            if (result.Length % 2 == 0)
            {
                return (result[(result.Length / 2) - 1] + result[(result.Length / 2)]) / 2.0;
            }
            else
            {
                return result[((result.Length + 1) / 2) - 1] + 0.0;
            }
        }
    }
}