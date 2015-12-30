using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Models
{
    public class Map
    {
        private int sizeX;
        private int sizeY; 

        public List<Settlement> settlements;
        public int[,] settlementsRadius;


        public Map(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;

            settlements = new List<Settlement>();
            settlementsRadius = new int[sizeX, sizeY];

            LoadSettlements();
        }

        public void LoadSettlements()
        {
            // Add to list of settlements
            settlements.Add(new Settlement("Pektha", 1, 155, new Tuple<int, int>(4, 6), settlements.Count+1));
            settlements.Add(new Settlement("Sathbri", 3, 155, new Tuple<int, int>(2, 5), settlements.Count+1));
            settlements.Add(new Settlement("Khirin", 1, 155, new Tuple<int, int>(0, 2), settlements.Count+1));

            // Add settlementID to settlementsRadius
            for (int i = 0; i < settlements.Count; i++)
            {                
                for (int j = 0; j < settlements[i].locations.Count; j++)
                {
                    // center
                    var x = settlements[i].locations[j].Item1;
                    var y = settlements[i].locations[j].Item2;

                    settlementsRadius[x, y] = settlements[i].settlementID;

                    // inflence sphere; only if level >= 3 
                    if (settlements[i].level >= 3)
                    {                     
                        // left
                        var left = settlements[i].locations[j].Item1 - 1;
                        if (left >= 0)
                        {
                            settlementsRadius[left, y] = settlements[i].settlementID;
                        }

                        // right
                        var right = settlements[i].locations[j].Item1 + 1;
                        if (right < this.sizeX)
                        {
                            settlementsRadius[right, y] = settlements[i].settlementID;
                        }

                        // top
                        var top = settlements[i].locations[j].Item2 - 1;
                        if (top >= 0)
                        {
                            settlementsRadius[x, top] = settlements[i].settlementID;
                        }

                        // bottom
                        var bottom = settlements[i].locations[j].Item2 + 1;
                        if (bottom < this.sizeY)
                        {
                            settlementsRadius[x, bottom] = settlements[i].settlementID;
                        }
                        // upper left
                        if (top >= 0 && left >= 0)
                        {
                            settlementsRadius[left, top] = settlements[i].settlementID;
                        }

                        // upper right
                        if (top >= 0 && right < this.sizeX)
                        {
                            settlementsRadius[right, top] = settlements[i].settlementID;
                        }

                        // lower left
                        if (bottom < this.sizeY && left >= 0)
                        {
                            settlementsRadius[left, bottom] = settlements[i].settlementID;
                        }

                        // lower right
                        if (bottom <this.sizeY && right < this.sizeX)
                        {
                            settlementsRadius[right, bottom] = settlements[i].settlementID;
                        }
                    }
                }
            }
        }

    }
}
