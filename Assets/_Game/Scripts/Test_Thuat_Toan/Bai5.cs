using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai5 : MonoBehaviour
{
    List<int> GetList(int n)
    {
        if (n % 2 != 0)
        {
            Debug.LogError("n phai chia het cho 2");
            return null;
        }

        List<int> result = new List<int>();

        // Tạo danh sách các phần tử từ 1 tới n/2
        List<int> temp = new List<int>();
        for (int i = 1; i <= n / 2; i++)
        {
            temp.Add(i);
        }

        for (int i = 0; i < n / 2; i++)
        {
            int index = Random.Range(0, temp.Count);
            int value = temp[index];

            // Thêm phần tử vào danh sách kết quả, viết 2 lần để có phần tử trùng nhau
            result.Add(value);
            result.Add(value);

            // Loại bỏ phần tử đã chọn từ danh sách temp
            temp.RemoveAt(index);
        }

        // Random
        for (int i = 0; i < result.Count; i++)
        {
            int tempValue = result[i];
            int randomIndex = Random.Range(i, result.Count);
            result[i] = result[randomIndex];
            result[randomIndex] = tempValue;
        }

        return result;
    }

    void Start()
    {
        List<int> list1 = GetList(10);
        Debug.Log("List 1: " + PrintList(list1));

        // Xét thêm 1 danh sách lấy ra các phần tử có vị trí random
        List<int> list2 = GetList(10);
        Debug.Log("List 2: " + PrintList(list2));
    }

    string PrintList(List<int> list)
    {
        string result = "{ ";
        foreach (int num in list)
        {
            result += num + ", ";
        }
        result = result.Remove(result.Length - 2); // Xóa dấu phẩy và khoảng trắng cuối cùng
        result += " }";
        return result;
    }
}
