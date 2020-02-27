# CSharpPoolManage

## 说明: C# 的一个程序池管理 比如创建一个数据库的 连接池

## 使用: 首先实现 ManagePool 下面的 IObjRealization 接口
> IObjRealization说明    
> 这个接口就是实现 需要管理的对象 是怎么创建的  
> 比如实现一个Mysql的连接 是怎么实现的 然后 在打开他  
> 下面 举一个例子  

## 创建一个mysql的连接池 例子

```
@Override
public class MysqlObj : IObjRealization<MySqlConnection>
{
    public MySqlConnection RealizationObj()
    {
        string ConnectionStr =ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //string ConnectionStr = "server=localhost;port=3306;user id=root;password=goodluck;database=mysql;Charset=utf8";
        MySqlConnection conn = new MySqlConnection(ConnectionStr);
        conn.Open();
        return conn;
    }
}
```

> 然后 OptionManagePool<MySqlConnection, MysqlObj>.GetOneObj(); 就可以直接获取一个现在 没有在使用的 连接对象

## OptionManagePool 说明
> OptionManagePool就是主要的操作类  
> 说明一下 StartTimerTime 和 RemoveObjectTime 这2个  
> 这2个参数都是有一个默认值的 如果不想使用 可以最开始就设置一下这2个参数的值  
> OptionManagePool<MySqlConnection, MysqlObj>.RemoveObjectTime = 0;  
> OptionManagePool<MySqlConnection, MysqlObj>.StartTimerTime = 0;  
> RemoveObjectTime 是对象从创建开始多长时间内 多少秒以后 移除 不在使用  
> StartTimerTime 是多长时间启动一下定时器 就是管理这个对象的时候 可以固定一个时间 执行一些操作  
> 具体可以看看我写的一些Demo  

