# CSharpPoolManage

## 说明: C# 的一个程序池管理 比如创建一个数据库的 连接池

## 使用  首先实现 ManagePool 下面的 IObjRealization 接口

## 比如创建一个mysql的连接池

```
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
