using PlataformaWEB.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlataformaWEB.Infrastructure
{
    public class API
    {
        public static class EconomicOperator
        {
            public static string UpdateEconomicOperator(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string CreateEconomicOperator(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetEOIDs(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetEOInfo(string baseUri, string eoid)
            {
                return $"{baseUri}/GetEOInfo?" +
                    $"eoid={HttpUtility.UrlEncode(eoid)}";
            }

            //public static string Summary(string baseUri, string code, int countryId, string enabled, int pageIndex, int pageSize, IEnumerable<Sort> sortInfo)
            //{
            //    string sortUrl = GetSortUrlQuery(sortInfo);
            //    string paginationUrl = GetPaginationUrlQuery(pageIndex, pageSize);
            //    return $"{baseUri}?" +
            //        $"&code={HttpUtility.UrlEncode(code)}" +
            //        $"&countryId={countryId}" +
            //        $"&isEnabled={enabled}" +
            //        $"&{paginationUrl}{sortUrl}";
            //}
        }

        public static class Facility
        {
            public static string UpdateFacility(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string CreateFacility(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetFIDs(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetFIDsByEOID(string baseUri, string eoid)
            {
                return $"{baseUri}/GetFIDsByEOID?" +
                    $"eoid={HttpUtility.UrlEncode(eoid)}";
            }

            public static string GetFacilityInfo(string baseUri, string fid)
            {
                return $"{baseUri}/GetFacilityInfo?" +
                    $"fid={HttpUtility.UrlEncode(fid)}";
            }

            //public static string Summary(string baseUri, string code, int countryId, string enabled, int pageIndex, int pageSize, IEnumerable<Sort> sortInfo)
            //{
            //    string sortUrl = GetSortUrlQuery(sortInfo);
            //    string paginationUrl = GetPaginationUrlQuery(pageIndex, pageSize);
            //    return $"{baseUri}?" +
            //        $"&code={HttpUtility.UrlEncode(code)}" +
            //        $"&countryId={countryId}" +
            //        $"&isEnabled={enabled}" +
            //        $"{paginationUrl}{sortUrl}";
            //}
        }

        public static class Machine
        {
            public static string UpdateMachine(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string CreateMachine(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetMIDs(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetMIDsByFID(string baseUri, string fid)
            {
                return $"{baseUri}/GetMIDsByFID?" +
                    $"fid={HttpUtility.UrlEncode(fid)}";
            }

            public static string GetMachineInfo(string baseUri, string mid)
            {
                return $"{baseUri}/GetMachineInfo?" +
                    $"mid={HttpUtility.UrlEncode(mid)}";
            }

            public static string GetProductsNameByMID(string baseUri, string mid)
            {
                return $"{baseUri}/GetProductsNameByMID?" +
                    $"mid={HttpUtility.UrlEncode(mid)}";
            }

            //public static string Summary(string baseUri, string code, int countryId, string enabled, int pageIndex, int pageSize, IEnumerable<Sort> sortInfo)
            //{
            //    string sortUrl = GetSortUrlQuery(sortInfo);
            //    string paginationUrl = GetPaginationUrlQuery(pageIndex, pageSize);
            //    return $"{baseUri}?" +
            //        $"&code={HttpUtility.UrlEncode(code)}" +
            //        $"&countryId={countryId}" +
            //        $"&isEnabled={enabled}" +
            //        $"{paginationUrl}{sortUrl}";
            //}
        }

        public static class Request
        {
            public static string CreateRequest(string baseUri)
            {
                return $"{baseUri}";
            }
        }

        public static class Arrival
        {
            public static string RegisterArrival(string baseUri)
            {
                return $"{baseUri}/arrivalToFacility";
            }
        }

        public static class Currency
        {
            public static string GetCurrencies(string baseUri)
            {
                return $"{baseUri}";
            }
        }

        public static class Invoice
        {
            public static string RegisterInvoice(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetInvoices(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetFilteredInvoices(string baseUri, DateFilters filters)
            { 
                return $"{baseUri}/GetFilteredInvoices?" +
                    $"&from={filters.From:yyyy-MM-dd}" +
                    $"&to={filters.To:yyyy-MM-dd}";
            }
        }
        public static class Dispatch
        {
            public static string RegisterDispatch(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetDispatches(string baseUri)
            {
                return $"{baseUri}";
            }

            public static string GetFilteredDispatches(string baseUri, DateFilters filters)
            {
                return $"{baseUri}/GetFilteredDispatches?" +
                    $"&from={filters.From:yyyy-MM-dd}" +
                    $"&to={filters.To:yyyy-MM-dd}";
            }
        }

        // Uso general
        private static string GetPaginationUrlQuery(int pageIndex, int pageSize)
        {
            return $"&pageindex={pageIndex}&pagesize={pageSize}";
        }
        private static string GetSortUrlQuery(IEnumerable<Sort> sortInfo)
        {
            int i = 0;
            string sortSerialized = string.Empty;
            if (sortInfo != null)
            {
                foreach (Sort sort in sortInfo)
                {
                    sortSerialized = sortSerialized + $"&sortInfo[{i}].direction={sort.Direction}&sortInfo[{i}].columnName={sort.ColumnName}";
                    i++;
                }
            }
            return sortSerialized;
        }

        private static string EscapeDataString(string value)
        {
            if (value != null)
            {
                return Uri.EscapeDataString(value);
            }
            return string.Empty;
        }
    }
}
