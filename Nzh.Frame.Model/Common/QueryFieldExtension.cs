using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Frame.Model.Common
{
    public static class QueryFieldExtension
    {
        private static Dictionary<string, string> dicItems;

        public static Dictionary<string, string> OrderFieldMapping()
        {
            dicItems = new Dictionary<string, string>();

            //common
            dicItems.Add("default", "rank_no"); // "排名" --（虚拟币列表， 交易所列表， 虚拟币行情)
            dicItems.Add("volume_day", "volume_day_usd");//"24小时成交额usd"  --（虚拟币列表， 交易所列表， 虚拟币行情）
            dicItems.Add("hot_level", "hot_level"); //"热度"   --（虚拟币列表， 交易所列表）
            dicItems.Add("price", "price_last_usd"); //"当前价格"  --（虚拟币列表， 虚拟币行情， 交易所行情）            

            //虚拟币列表（default,price,volume_day,market_cap,circulating_supply,change,change_day,change_week,hot_level（默认，价格，24h成交额，总市值，流通量，1h涨跌幅，24h涨跌幅，7d涨跌幅，热度））
            dicItems.Add("market_cap", "market_cap_usd"); //"流通市值" 
            dicItems.Add("circulating_supply", "circulating_supply"); //"流通量"
            dicItems.Add("change_hour", "change_rate_hour_usd");
            dicItems.Add("change_day", "change_rate_day_usd"); //24小时价格波动率usd %
            dicItems.Add("change_week", "change_rate_week_usd");//7天价格波动率usd %



            //交易所列表（default,volume_day,trade_pair_count,hot_level）（默认，价格，24h成交额，交易对数量，热度等级）
            dicItems.Add("trade_pair_count", "trade_pair_count"); //交易对数量

            //交易所行情
            dicItems.Add("vol", "vol"); //最近24小时成交量
            dicItems.Add("change", "change");//"涨跌" -- (交易所行情）

            return dicItems;
        }

        public static Dictionary<string, string> LanguageMapping()
        {
            dicItems = new Dictionary<string, string>();
            dicItems.Add("zh-cn", "zh-CN"); //中国
            dicItems.Add("zh-hk", "zh-HK"); //TODO 中国香港
            dicItems.Add("en", "en-US"); //英文
            dicItems.Add("ko", "ko-KR"); //韩国
            dicItems.Add("ja", "ja-JP"); //日本

            return dicItems;
        }
    }
}
