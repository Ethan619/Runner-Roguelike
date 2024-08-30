using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// A Collection of extension/utility methods for Lists
/// </summary>
public static class ListExt {
	/// <summary>
	/// Gets all elements from the list that are not set to null.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <returns></returns>
	public static List<T> NonNull<T>(this List<T> list) where T : class {
		List<T> nList = new List<T>(list);
		nList.RemoveAll(n => n == null);
		return nList;
    }
	
	/// <summary>
	/// Resizes a list. Removes elements from the end when making the list smaller. Adds default(T) elements to the list when making it bigger.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <param name="newCount"></param>
	public static void Resize<T>(this List<T> list, int newCount) {
		if(newCount <= 0) {
			list.Clear();
		} else {
			while(list.Count > newCount) {
				list.RemoveAt(list.Count - 1);
			}
			while(list.Count < newCount) {
				list.Add(default(T));
			}
		}
	}

	/// <summary>
	/// Checks whether the given index exists within the List
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <param name="index"></param>
	/// <returns></returns>
	public static bool ContainsIndex<T>(this List<T> list, int index) {
		return index >= 0 && index < list.Count;
	}

	/// <summary>
	/// Removes the provided amount of elements from the end of the list.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <param name="amount"></param>
	public static void RemoveFromEnd<T>(this List<T> list, int amount) {
		if(amount > list.Count) {
			list.Clear();
			return;
		}

		for(int i = 0; i < amount; i++) {
			list.RemoveAt(list.Count - 1);
		}
	}

	/// <summary>
	/// Gets the provided amount of elements from the end of the list
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <param name="amount"></param>
	/// <returns></returns>
	public static List<T> GetFromEnd<T>(this List<T> list, int amount) {
		List<T> results = new List<T>();

		if(list.Count <= amount) {
			results.AddRange(list);
		} else {
			results.AddRange(list.GetRange(list.Count - amount, amount));
		}

		return results;
	}

	
	/// <summary>
	///	Get a list of random elements from the array. This can include duplicates.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <param name="amount"></param>
	/// <returns></returns>
	public static List<T> Random<T>(this List<T> list, int amount) {
		List<T> res = new List<T>();
		if(list.Count > 0) {
			for(int i = 0; i < amount; i++) {
				res.Add(list.Random());
			}
		}
		return res;
    }

	

	/// <summary>
	/// Get a random element from the list between two indices. maxIndex is exclusive.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <param name="minIndex"></param>
	/// <param name="maxIndex"></param>
	/// <returns></returns>
	public static T Random<T>(this List<T> list, int minIndex, int maxIndex) {
		int index = UnityEngine.Random.Range(minIndex, maxIndex);
		return list[index];
		
    }

	
	/// <summary>
	/// Get a new list containing all of the current list's (T)objects casted into type(K)
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="K"></typeparam>
	/// <param name="list"></param>
	/// <returns></returns>
	public static List<K> Cast<T, K>(this List<T> list) where K : T {
		List<K> list2 = new List<K>();
		foreach(T t in list) {
			list2.Add((K)t);
		}

		return list2;
	}

	/// <summary>
	/// Get a random element from the list.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <returns></returns>
	public static T Random<T>(this List<T> list) {
		if(list.Count == 0) {
			throw new System.Exception("Can not get a random element from an empty list.");
		} else if(list.Count == 1) {
			return list[0];
		}
		return list[UnityEngine.Random.Range(0, list.Count)];

	}

	/// <summary>
	/// Gets the last element in a list
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <returns></returns>
	public static T Last<T>(this List<T> list) {
		if(list.Count < 1) {
			throw new System.Exception("Can not get the last element of an empty list.");
		}
		return list[list.Count - 1];
	}

	/// <summary>
	/// Randomly Shuffles the list.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <returns></returns>
	public static void Shuffle<T>(this List<T> list) {
		for(int i = 0; i < list.Count; i++) {

			int r = UnityEngine.Random.Range(0, list.Count);

			T value = list[r];
			list[r] = list[0];
			list[0] = value;
		}
	}

	/// <summary>
	/// Gets the first element in the list
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <returns></returns>
	public static T GetFirst<T>(this List<T> list) {
		return list[0];
	}

    /// <summary>
	/// Removes the provided amount of elements from the start of the list.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <param name="amount"></param>
    public static void RemoveFromStart<T>(this List<T> list, int amount) {
        if (amount > list.Count) {
            list.Clear();
            return;
        }

        for (int i = 0; i < amount; i++) {
            list.RemoveAt(0);
        }
    }


	/// <summary>
	/// Gets the provided amount of elements from the start of the list
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <param name="amount"></param>
	/// <returns></returns>
	public static List<T> GetFromStart<T>(this List<T> list, int amount) {
		List<T> results = new List<T>();

		if (list.Count <= amount) {
			results.AddRange(list);
		} else {
			results.AddRange(list.GetRange(0, amount));
		}

		return results;
	}





	/// <summary>
	/// Gets half of the elements in the list.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <param name="ceil">Whether to include the middle element in the list of odd elements</param>
	/// <returns></returns>
    public static List<T> FirstHalf<T>(this List<T> list, bool ceil = true) {
		List<T> halfList = new List<T>();
		if(list.Count < 2) {
			halfList.AddRange(list);
        } else {

			int count = list.Count / 2;
			count += ceil && list.Count.IsOdd() ? 1 : 0;
			halfList.AddRange(list.GetFromStart(count));
        }
		return halfList;
    }

	/// <summary>
	/// Shuffles a list a given number of times
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <param name="times"></param>
	/// <returns></returns>
	public static List<T> Shuffle<T>(this List<T> list, int times) {
		for(int i = 0; i < times; i++) {
			list.Shuffle();
		}
		return list;
	}

	/// <summary>
	/// Creates a copy of a list
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <returns></returns>
	public static List<T> Copy<T>(this List<T> list) {
		return new List<T>(list);
    }



	/// <summary>
	/// Removes duplicated elements from the list.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	public static void RemoveDuplicates<T>(this List<T> list) {
		List<T> distinctList = list.Distinct().ToList();
		list.Clear();
		list.AddRange(distinctList);
	}
}