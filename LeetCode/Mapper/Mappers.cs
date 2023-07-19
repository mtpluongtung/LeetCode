using LeetCode.Extension;
using System;
using System.Collections.Generic;
using System.Linq;

public static class Mappers
{

    public static TData Maps<TSource, TData>(TSource source) where TData : class where TSource : class
    {
        TData data = Activator.CreateInstance<TData>();
        var dataProps = typeof(TData).GetProperties();
        var sourceProps = typeof(TSource).GetProperties();

        foreach (var sourceProp in sourceProps)
        {
            var sameProp = dataProps.FirstOrDefault(dataProp =>
                dataProp.Name.ToLower() == sourceProp.Name.ToLower());
            if (sameProp != null)
                if (sourceProp.PropertyType.IsCastableTo(sameProp.PropertyType))
                {

                    sameProp.SetValue(data, sourceProp.GetValue(source).ToType(sameProp.PropertyType));

                }

            if (sourceProp.Name.ToLower() == "IsActive".ToLower())
            {
                sameProp = dataProps.FirstOrDefault(x => x.Name.ToLower() == "status");
                if (sameProp != null)
                    sameProp.SetValue(data, (sourceProp.GetValue(source) as bool?) == true ? 1 : 0);
            }

            if (sourceProp.Name.ToLower() == "Status".ToLower())
            {
                sameProp = dataProps.FirstOrDefault(x => x.Name.ToLower() == "isactive");
                if (sameProp != null)
                    sameProp.SetValue(data, (sourceProp.GetValue(source) as int?) == 1);
            }
        }
        return data;
    }

    public static List<TData> Maps<TSource, TData>(this IEnumerable<TSource> sourceList) where TData : class where TSource : class
    {
        List<TData> datas = Activator.CreateInstance<List<TData>>();
        foreach (var source in sourceList)
        {
            TData data = Activator.CreateInstance<TData>();
            var dataProps = typeof(TData).GetProperties();
            var sourceProps = typeof(TSource).GetProperties();

            foreach (var sourceProp in sourceProps)
            {
                var sameProp = dataProps.FirstOrDefault(dataProp =>
                    dataProp.Name.ToLower() == sourceProp.Name.ToLower());
                if (sameProp != null)
                    if (sourceProp.PropertyType.IsCastableTo(sameProp.PropertyType))
                    {

                        sameProp.SetValue(data, sourceProp.GetValue(source).ToType(sameProp.PropertyType));

                    }

                if (sourceProp.Name.ToLower() == "IsActive".ToLower())
                {
                    sameProp = dataProps.FirstOrDefault(x => x.Name.ToLower() == "status");
                    if (sameProp != null)
                        sameProp.SetValue(data, (sourceProp.GetValue(source) as bool?) == true ? 1 : 0);
                }

                if (sourceProp.Name.ToLower() == "Status".ToLower())
                {
                    sameProp = dataProps.FirstOrDefault(x => x.Name.ToLower() == "isactive");
                    if (sameProp != null)
                        sameProp.SetValue(data, (sourceProp.GetValue(source) as int?) == 1);
                }
            }
            datas.Add(data);
        }

        return datas;
    }
}
