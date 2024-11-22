using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 相同点

        //1.都是用来存储Json
        //2.Json文档编码格式都是UTF-8
        //3.都通过静态方法来操作Json数据

        #endregion

        #region 不同点

        //1.JsonUtility是Unity自带的 LitJson是第三方插件
        //2.JsonUtility对自定义类需要加特性，LitJson不需要
        //3.JsonUtility支持私有变量（加特性），LitJson不支持
        //4.JsonUtility不支持字典，LitJson支持字典（但是键对必须是string）
        //5.JsonUtility不支持集合转换，LitJson支持
        //6.JsonUtility对自定义类需要无参构造，LitJson不需要
        //7.JsonUtility存空对象为默认值，LitJson存空对象为null

        #endregion

        #region 常用LitJson方法

        //根据实际需求
        //建议使用LitJson，因为LitJson功能更加强大
        //不用加特性，不用无参构造，支持字典，支持集合转换，存储null更准确

        #endregion
    }
}
