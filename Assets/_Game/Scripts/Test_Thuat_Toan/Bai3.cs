using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai3 : MonoBehaviour
{
    static void Bai3SapXepDanhSach(List<int> list)
    {
        int maxLength = 0; 
        List<List<int>> listChild = new List<List<int>>();

        List<int> currentList = new List<int>(); 
        currentList.Add(list[0]); 

        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] > list[i - 1]) 
            {
                currentList.Add(list[i]); 
            }
            else 
            {
                // Kiểm tra và cập nhật độ dài lớn nhất của dãy con tăng dần
                if (currentList.Count > maxLength)
                {
                    maxLength = currentList.Count;
                    listChild.Clear();
                    listChild.Add(new List<int>(currentList));
                }
                else if (currentList.Count == maxLength)
                {
                    listChild.Add(new List<int>(currentList));
                }

                currentList.Clear(); 
                currentList.Add(list[i]);
            }
        }

        // Kiểm tra và cập nhật độ dài lớn nhất của dãy con tăng dần (đối với trường hợp dãy con tăng dần kết thúc ở phần tử cuối cùng của danh sách)
        if (currentList.Count > maxLength)
        {
            maxLength = currentList.Count;
            listChild.Clear();
            listChild.Add(new List<int>(currentList));
        }
        else if (currentList.Count == maxLength)
        {
            listChild.Add(new List<int>(currentList));
        }

        // In ra các dãy con sau khi sắp xếp
        Debug.Log("Dãy sau khi sắp xếp:");
        foreach (List<int> subsequence in listChild)
        {
            foreach (int num in subsequence)
            {
                Debug.Log(num + " ");
            }
            Debug.Log("");
        }
    }

    void Start()
    {
        List<int> list1 = new List<int> { 1, 3, 5, 6, 7, 4, 3, 1, 7 };
        Bai3SapXepDanhSach(list1);

        List<int> list2 = new List<int> { 1, 3, 5, 6, 7, 4, 4, 6, 8, 9, 10 };
        Bai3SapXepDanhSach(list2);
    }
}
