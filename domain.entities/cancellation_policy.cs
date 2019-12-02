using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace domain.entities
{
    #region CancellationPolicy

    [Serializable]
    [XmlRoot(ElementName = "CancellationPolicy")]
    public class CancellationPolicy
    {
        public string CurrencyCode { get; set; }
        public FirstDayCostCancellation FirstDayCostCancellation { get; set; }
        public string Description { get; set; }
        public List<PolicyRules> PolicyRules { get; set; }
    }

    public class FirstDayCostCancellation
    {
        public string Hour { get; set; }
    }
    public class PolicyRules
    {
        public int From { get; set; }
        public int To { get; set; }
        /// <summary>
        /// yyyy:MM:dd
        /// </summary>
        public DateTime DateFrom { get; set; }
        /// <summary>
        /// hh:mm
        /// </summary>
        public string DateFromHour { get; set; }
        public string StayLenghtFrom { get; set; }
        /// <summary>
        /// yyyy:MM:dd
        /// </summary>
        public DateTime DateTo { get; set; }
        /// <summary>
        /// hh:mm
        /// </summary>
        public string DateToHour { get; set; }
        /// <summary>
        /// • V - Before the check-in date. 
        /// • R - After the booking confirmation date 
        /// • S - No Show 
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Price value of the rule (in CurrencyCode). 
        /// </summary>
        public double FixedPrice { get; set; }
        public double PercentPrice { get; set; }
        public double MostExpensiveNightPrice { get; set; }
        public int Nights { get; set; }
        public int StayLengthFrom { get; set; }
        public int StayLengthTo { get; set; }
        /// <summary>
        /// • Average - this is the average price of all nights 
        /// • FirstNight - the price of first night 
        /// • MostExpensiveNight - the price of the most expensive night
        /// </summary>
        public string ApplicationTypeNights { get; set; }
        public double FirstNightPrice { get; set; }

    }


    /*other class */
    public class AdditionalPolicies
    {
        public List<AdditionalPoliciesGroup> AdditionalPoliciesGroup { get; set; }
    }

    public class AdditionalPoliciesGroup
    {
        /// <summary>
        /// • C – Cost.
        /// • S – Sell
        /// </summary>
        public string Type { get; set; }
        public string CurrencyCode { get; set; }
    }
    public class AdditionalPolicy
    {
        public string PolicyType { get; set; }
        public bool Allowed { get; set; }
        public string Description { get; set; }
        public List<PolicyRules> PolicyRules { get; set; }
    }

    #endregion


    #region Request detail 
    [XmlRoot(ElementName = "CancellationPolicy")]
    public class RequestDetail
    {
        [XmlAttributeAttribute("Version")]
        public string Version { get; set; }
        [XmlAttributeAttribute("Language")]
        public string Language { get; set; }

    }

    public class GenericDataCatalogueRequest
    {
        [XmlAttributeAttribute("Type")]
        public string Type { get; set; }
    }
    #endregion
}
