using Catan.Players;
using Catan.ResourcePhase;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Catan.TradePhase
{
    public static class Trader
    {
        /// <summary>
        /// Trades the resources specified in the offer arrays between players. Resources in p1Offer will be taken from p1 and given to p2, and vice versa for p2Offer.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p1Offer"></param>
        /// <param name="p2Offer"></param>
        public static void Trade(Player p1, Player p2, Resource[] p1Offer, Resource[] p2Offer)
        {
            foreach (Resource r in p1Offer)
            {
                int amount = r.amount;
                p1.resources.Where(rs => rs.type == r.type).First().amount -= amount;
                p2.resources.Where(rs => rs.type == r.type).First().amount += amount;
            }
            foreach (Resource r in p2Offer)
            {
                int amount = r.amount;
                p2.resources.Where(rs => rs.type == r.type).First().amount -= amount;
                p1.resources.Where(rs => rs.type == r.type).First().amount += amount;
            }
        }

        /// <summary>
        /// Discards the resources specified in the offer array from the specified player.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="offer"></param>
        public static void Discard(Player p, Resource[] offer)
        {
            foreach (Resource r in offer)
            {
                p.resources.Where(rs => rs.type == r.type).First().amount -= r.amount;
            }
        }

        public static bool Request(Player p1, Player p2, Resource[] p1Offer, Resource[] p2Offer)
        {
            if (p2.isAI)
            {
                if (p2.agent.ChooseAcceptTradeDeal(p1, p2, p1Offer, p2Offer))
                {
                    Trade(p1, p2, p1Offer, p2Offer);
                    return true;
                }
                return false;
            }
            else
            {
                // Entry point to accept trade request here
                return false;
            }
        }
    }
}