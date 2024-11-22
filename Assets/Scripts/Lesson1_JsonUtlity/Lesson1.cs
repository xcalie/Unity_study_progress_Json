using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
public class Student
{
    public int age;
    public string name;

    public Student()
    {
    }

    public Student(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}


public class RoleInfo
{
    public int id;
    public int speed;
    public int volume;
    public string resName;
    public int scale;
}

public class Teacher
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


public class Roles
{
    public List<RoleInfo> roles;
}

public class Lesson1 : MonoBehaviour
{
    void Start()
    {
        #region JsonUtlity

        // JsonUtility 是Unity自带的用于解析Json的公共类
        //1.将内存中对象序列化为Json格式的字符串
        //2.将Json字符串反序列化为类对象

        #endregion

        #region 在文件中读取字符串

        //1.存储字符串到指定路径的文件夹中
        //第一个参数 填写的是 存储的路径
        //第二个参数 填写的是 存储的字符串内容
        File.WriteAllText(Application.persistentDataPath + "/Test.json", "Hello World");
        print(Application.persistentDataPath);
        //2.读取指定路径的文件夹中的字符串
        string str = File.ReadAllText(Application.persistentDataPath + "/Test.json");
        print(str);

        #endregion

        #region 使用JsonUtility将对象序列化

        //序列化：把内存中的数据 存储在硬盘上
        //方法:
        //JsonUtility.ToJson(对象)
        Teacher t = new Teacher();
        t.name = "XC";
        t.age = 18;
        t.sex = true;
        t.testF = 1.1f;
        t.testD = 1.2;

        t.ids = new int[] { 1, 2, 3, 4, 5 };
        t.ids2 = new List<int> { 6, 7, 8, 9, 10 };
        t.dic = new Dictionary<int, string>() { {1, "123"}, { 2, "234" } };
        t.dic2 = new Dictionary<string, string>() { { "1", "123" }, { "2", "234" } };

        t.s1 = new Student(1, "小红");
        t.s2s = new List<Student>() { new Student(2, "小明"), new Student(3, "小刚") };

        //JsonUtility.ToJson(对象)提供了线程的方法 可以把类对象 序列化为 json字符串
        string jsonStr = JsonUtility.ToJson(t);
        File.WriteAllText(Application.persistentDataPath + "/Teacher.json", jsonStr);



        #endregion

        #region 使用JsonUtility将字符串反序列化

        //反序列化：把硬盘上的数据 读取到内存中
        //方法:
        //JsonUtility.FromJson<T>(json字符串)
        jsonStr = File.ReadAllText(Application.persistentDataPath + "/Teacher.json");
        //使用Json字符串的内容 转换为类对象
        Teacher t2 = JsonUtility.FromJson(jsonStr, typeof(Teacher)) as Teacher;
        Teacher t3 = JsonUtility.FromJson<Teacher>(jsonStr);

        //注意
        //如果Json中数据少了,读取到内存中类对象是不会报错

        #endregion

        #region 相关事项

        //1.JsonUtility无法直接读取集合 需要又一个对象包裹
        string jsonStr1 =  File.ReadAllText(Application.persistentDataPath + "/RoleInfo.json");
        Roles roles = JsonUtility.FromJson<Roles>(jsonStr1);

        //2.文本编码格式需要时UTF-8 不然无法加载

        #endregion

        #region 注意

        //1.float序列化是看起来会有一些误差
        //2.自定义类需要加上序列化特性 [System.Serializable]
        //3.想要序列化私有变量 需要加上特性 [SerializeField]
        //4.JsonUtility不支持Dictionary的序列化
        //5.JsonUtility存储null对象不会是null 而是默认值

        #endregion

        #region 总结

        //1.必备知识点 一 File存读取字符串 ReadAllText和WriteAllText
        //2.JsonUtility 提供的序列化和反序列化方法 ToJson和FromJson
        //3.自定义类需要加上序列化特性 [System.Serializable]
        //4.私有化保护成员 需要加上特性 [SerializeField]
        //5.JsonUtility不支持Dictionary的序列化
        //6.JsonUtility不能直接将数据反序列化为数据集合
        //7.Json文档编码格式必须UTF-8

        #endregion
    }

}
