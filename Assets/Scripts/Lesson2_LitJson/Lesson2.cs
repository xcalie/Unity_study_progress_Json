using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;

public class Student1
{
    public int age;
    public string name;

    public Student1()
    {
    }

    public Student1(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}


public class Teacher1
{
    public string name;
    public int age;
    public bool sex;
    public float testF;
    public double testD;

    public int[] ids;
    public List<int> ids2;
    public Dictionary<int, string> dic;
    public Dictionary<string, string> dic2;

    public Student s1;
    public List<Student> s2s;

    private int privateI;
    protected int protectedI;
}


public class Lesson2 : MonoBehaviour
{
    private void Start()
    {
        #region 使用LitJson解析Json字符串

        Teacher1 t = new Teacher1();
        t.name = "XC";
        t.age = 18;
        t.sex = true;
        t.testF = 1.1f;
        t.testD = 1.2;

        t.ids = new int[] { 1, 2, 3, 4, 5 };
        t.ids2 = new List<int> { 6, 7, 8, 9, 10 };
        t.dic = new Dictionary<int, string>() { { 1, "123" }, { 2, "234" } };
        t.dic2 = new Dictionary<string, string>() { { "1", "123" }, { "2", "234" } };

        t.s1 = new Student(1, "小红");
        t.s2s = new List<Student>() { new Student(2, "小明"), new Student(3, "小刚") };

        string jsonStr = JsonMapper.ToJson(t);
        File.WriteAllText(Application.persistentDataPath + "/TestTeacher.json", jsonStr);

        //注意
        //1.相对JsonUtility，LitJson不需要在类前面加[Serializable]标签
        //2.LitJson不支持私有变量的序列化
        //3.支持字典类型，但是字典的key只能是string类型
        //5.LitJson可以准确的保存null类型

        #endregion

        #region 使用LitJson解析Json字符串 反序列化

        //方法
        //JsonMapper.ToObject<T>(json字符串)
        jsonStr = File.ReadAllText(Application.persistentDataPath + "/TestTeacher.json");
        Teacher1 t1 = JsonMapper.ToObject<Teacher1>(jsonStr);

        //注意:
        //1.类结构必须无参构造,否则反序列化时会报错
        //2.字典虽然支持 但是键在使用时会有问题 需要使用字符串类型

        #endregion

        #region 注意事项

        //1.LitJson可以直接读取集合类型的json字符串,包括字典
        jsonStr = File.ReadAllText(Application.persistentDataPath + "/RoleInfo.json");
        RoleInfo[] arr = JsonMapper.ToObject<RoleInfo[]>(jsonStr);

        List<RoleInfo> list = JsonMapper.ToObject<List<RoleInfo>>(jsonStr);

        //2.LitJson必须要UTF-8

        #endregion

        #region 总结

        //1.LitJson的方法 JsonMapper.ToJson() 和 JsonMapper.ToObject<T>()
        //2.LitJson无需加特性
        //3.LitJson不支持私有变量
        //4.LitJson支持字典类型
        //5.LitJson可以直接将集合类型的json字符串转换为集合类型
        //6.LitJson无效无参构造
        //7.LitJson必须要UTF-8

        #endregion
    }
}
