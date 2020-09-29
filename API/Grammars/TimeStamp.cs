        using System;
        namespace GAPI.Grammars {

            public class DateTimeUtil {

                /// <summary>
                /// 时间戳计时开始时间
                /// </summary>
                private static DateTime timeStampStartTime = new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
               
                /// <summary>
                /// 10位时间戳（单位：秒）转换为DateTime
                /// </summary>
                /// <param name="timeStamp">10位时间戳（单位：秒）</param>
                /// <returns>DateTime</returns>
                public  DateTime TimeStampToDateTime (long timeStamp) {
                    return timeStampStartTime.AddSeconds (timeStamp).ToLocalTime ();
                }
               
               
               
                public long ConvertToTimeStmap (DateTime dt) {
                    return (dt.ToUniversalTime ().Ticks - 621355968000000000) / 10000000;

                }

                                /// <summary>
                /// 将时间戳转化为对应的时间
                /// </summary>
                /// <param name="time"></param>
                /// <returns></returns>
                public DateTime ConvertToDateTime (long time) {
                    DateTime timeStamp = new DateTime (1970, 1, 1); //得到1970年的时间戳
                    // 8 * 60 * 60是加8个小时=北京时间1970年1月1日8时
                    long t = (time + 8 * 60 * 60) * 10000000 + timeStamp.Ticks;
                    DateTime dt = new DateTime (t);
                    return dt;
                }


               



            }

        }