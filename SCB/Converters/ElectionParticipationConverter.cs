﻿using SCB.DTO;
using SCB.Interfaces;
using SCB.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Converters
{
    public class ElectionParticipationConverter : IConverter<ElectionParticipationResult, Election[]>
    {
        public Election[] Convert(ElectionParticipationResult Value)
        {
            var t_Years = Value.data.Select(D => D.key[1]).Distinct();
            return t_Years.Select(Y =>
            {
                return _ConvertDataToElection(new Year { Value = int.Parse(Y) }, Value.data);
            })
            .ToArray();
        }

        private Election _ConvertDataToElection(Year Year, Data[] ElectionData)
        {
            return new Election
            {
                Year = Year,
                Results = ElectionData
                .Where(D => D.key[1] == Year.Value.ToString())
                .Select(D => _ConvertToElectionResult(D))
                .ToList()
            };
        }

        private ElectionResult _ConvertToElectionResult(Data Data)
        {
            return new ElectionResult
            {
                Region = new Region { Code = int.Parse(Data.key[0]) },
                Participation = new Participation
                {
                    Value = _ConvertStringToPercentage(Data.values[0])
                }
            };
        }

        private Percentage _ConvertStringToPercentage(string StrValue)
        {
            return _ConvertToDecimalPercentage(decimal.Parse(StrValue, new CultureInfo("en-US")));
        }

        private Percentage _ConvertToDecimalPercentage(decimal Value)
        {
            return new Percentage { Value = Value * 0.01m };
        }
    }
}
