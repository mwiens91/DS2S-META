﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS2S_META.Randomizer
{
    internal static class ShopRules
    {
        private static LinkedShopEvent TradeShop(int keepID, params int[] removeIDs)
        {
            var lse = new LinkedShopEvent(keepID, removeIDs)
            {
                IsTrade = true
            };
            return lse;
        }
        private static LinkedShopEvent FreeTradeShop(int keepID, params int[] removeIDs)
        {
            var lse = new LinkedShopEvent(keepID, removeIDs)
            {
                IsTrade = true,
                FreeTrade = true,
            };
            return lse;
        }
        private static LinkedShopEvent TradeShopCopy(int copyID, int fillByCopy, params int[] removeIDs)
        {
            var lse = new LinkedShopEvent()
            {
                CopyID = copyID,
                FillByCopy = fillByCopy,
                RemoveIDs = removeIDs.ToList(),

                IsTrade = true,
                FreeTrade = false,
            };
            return lse;
        }
        private static LinkedShopEvent ShopCopy(int copyID, int fillByCopy)
        {
            var lse = new LinkedShopEvent()
            {
                FillByCopy = fillByCopy,
                CopyID = copyID,

                IsTrade = false,
                FreeTrade = false,
            };
            return lse;
        }
        private static LinkedShopEvent KeepRemove(int keepID, params int[] removeIDs)
        {
            return new LinkedShopEvent(keepID, removeIDs);
        }

        internal static List<LinkedShopEvent> GetLinkedEvents() 
        {
            List<LinkedShopEvent> LinkedEvents = new List<LinkedShopEvent>()
            {
                // Maughlin:
                ShopCopy(76100211, 76100219), // Maughlin royal sodlier helm
                ShopCopy(76100212, 76100220), // Maughlin royal sodlier armour
                ShopCopy(76100213, 76100221), // Maughlin royal sodlier gauntlets
                ShopCopy(76100214, 76100222), // Maughlin royal sodlier leggings
                ShopCopy(76100215, 76100223), // Maughlin elite knight helm
                ShopCopy(76100216, 76100224), // Maughlin elite knight armour
                ShopCopy(76100217, 76100225), // Maughlin elite knight gauntlets
                ShopCopy(76100218, 76100226), // Maughlin elite knight leggings
                //
                ShopCopy(70400000, 70400004), // Gilligan club
                ShopCopy(70400001, 70400005), // Gilligan claws
                ShopCopy(70400002, 70400006), // Gilligan whip
                ShopCopy(70400003, 70400007), // Gilligan wooden shield
                ShopCopy(70400200, 70400204), // Gilligan thief mask
                ShopCopy(70400201, 70400205), // Gilligan black leather armour
                ShopCopy(70400202, 70400206), // Gilligan black leather gloves
                ShopCopy(70400203, 70400207), // Gilligan black leather boots
                ShopCopy(70400500, 70400501), // Gilligan ladder miniature
                ShopCopy(70400600, 70400603), // Gilligan ooze
                ShopCopy(70400601, 70400604), // Gilligan lacerating knife
                ShopCopy(70400602, 70400605), // Gilligan bleeding serum
                //
                ShopCopy(72600400, 72600401), // Gavlan Ring of Giants
                ShopCopy(72600400, 72600402), // Gavlan Ring of Giants
                ShopCopy(72600600, 72600604), // Gavlan poison moss
                ShopCopy(72600601, 72600605), // Gavlan rotten pine resin
                ShopCopy(72600602, 72600606), // Gavlan poison throwing knife
                ShopCopy(72600603, 72600607), // Gavlan poison arrow
                //
                KeepRemove(75400600, 75400601), // Melentia lifegems
                KeepRemove(75400609, 75400610, 75400611, 75400612, 75400613, 75400614), // Melentia brightbugs

                // Note: Chloanne's descriptions are messed up:
                KeepRemove(76200600, 76200601), // Chloanne bonfire ascetic
                KeepRemove(76200602, 76200603), // Chloanne large titanite shard
                KeepRemove(76200604, 76200605), // Chloanne titanite chunk

                // Note: McDuff's descriptions are messed up:
                KeepRemove(76430000, 76430007), // McDuff Uchi
                KeepRemove(76430001, 76430008), // McDuff Bastard Sword
                KeepRemove(76430002, 76430009), // McDuff Greataxe
                KeepRemove(76430003, 76430010), // Mcduff Winged Spear
                KeepRemove(76430004, 76430011), // McDuff Scythe
                KeepRemove(76430005, 76430012), // McDuff Longbow
                KeepRemove(76430006, 76430013), // McDuff Light Crossbow
                KeepRemove(76430100, 76430102), // McDuff Royal Kite Shield
                //
                KeepRemove(76600300, 76600308), // Carhillion Soul Arrow
                KeepRemove(76600301, 76600309), // Carhillion Great Soul Arrow
                KeepRemove(76600302, 76600310), // Carhillion Heavy Soul Arrow
                KeepRemove(76600303, 76600311), // Carhillion Great Heavy Soul Arrow
                KeepRemove(76600304, 76600312), // Carhillion Shockwave
                KeepRemove(76600305, 76600313), // Carhillion Soul Spear Barrage
                KeepRemove(76600306, 76600314), // Carhillion Magic Weapon
                KeepRemove(76600307, 76600315), // Carhillion Yearn
                //
                TradeShop(76801000, 76801200), // Straid Pursuer UGS
                TradeShop(76801001, 76801201), // Straid Pursuer Greatshield
                TradeShop(76801002, 76801202), // Straid Giant Stone Axe
                TradeShop(76801003, 76801203), // Straid Dragonrider Halberd
                TradeShop(76801004, 76801204), // Straid Dragonrider Bow
                TradeShop(76801005, 76801205), // Straid Dragonrider Twinblade
                TradeShop(76801006, 76801206), // Straid Dragonrider Greatshield
                TradeShop(76801007, 76801207), // Straid Warped Sword
                TradeShop(76801008, 76801208), // Straid Barbed Club
                TradeShop(76801009, 76801209), // Straid Arced Sword
                TradeShop(76801010, 76801210), // Straid Chariot Lance
                TradeShop(76801011, 76801211), // Straid Shield Crossbow
                TradeShop(76801012, 76801212), // Straid Roaring Halberd
                TradeShop(76801013, 76801213), // Straid Bone Scythe
                TradeShop(76801014, 76801214), // Straid Mytha's Bent Blade
                TradeShop(76801015, 76801215), // Straid Smelter Sword
                TradeShop(76801016, 76801216), // Straid Spotted Whip
                TradeShop(76801017, 76801217), // Straid Gargoyles Bident
            
                TradeShop(76801100, 76801300), // Straid Heavy Homing Soul Arrow
                TradeShop(76801101, 76801301), // Straid Toxic Mist
                TradeShop(76801102, 76801302), // Straid Soul Shower
                TradeShop(76801103, 76801303), // Straid Acid Surge
                TradeShop(76801104, 76801304), // Straid Sacred Oath
                TradeShop(76801105, 76801305), // Straid Repel
                TradeShop(76801106, 76801306), // Straid Lifedrain Patch
                //
                KeepRemove(76900300, 76900310), // Licia Heal
                KeepRemove(76900301, 76900311), // Licia Med Heal
                KeepRemove(76900302, 76900312), // Licia Great Heal Excerpt
                KeepRemove(76900303, 76900313), // Licia Replenishment
                KeepRemove(76900304, 76900314), // Licia Respelendent Life
                KeepRemove(76900305, 76900315), // Licia Caressing Prayer
                KeepRemove(76900306, 76900316), // Licia Force
                KeepRemove(76900307, 76900317), // Licia Lightning Spear
                KeepRemove(76900308, 76900318), // Licia Homeward
                KeepRemove(76900309, 76900319), // Licia Guidance
            
                //
                KeepRemove(77700600, 77700604), // Shalquoir Prism Stones
                KeepRemove(77700601, 77700605), // Shalquoir Alluring Skulls
                KeepRemove(77700602, 77700606), // Shalquoir Lloyd's Amulet
                KeepRemove(77700603, 77700607), // Shalquoir Homeward Bone
                //
                KeepRemove(78400300, 78400308), // Cromwell Great Heal
                KeepRemove(78400301, 78400309), // Cromwell Replenishment
                KeepRemove(78400302, 78400310), // Cromwell Caressing Prayer
                KeepRemove(78400303, 78400311), // Cromwell Force
                KeepRemove(78400304, 78400312), // Cromwell Emit Force
                KeepRemove(78400305, 78400313), // Cromwell Heavenly Thunder
                KeepRemove(78400306, 78400314), // Cromwell Perserverance
                KeepRemove(78400307, 78400315), // Cromwell Scraps of Life

                // Ornifex
                FreeTradeShop(77602000), // Ornifex Dragonslayer Spear
                FreeTradeShop(77602001), // Ornifex Lost Sinner Sword
                FreeTradeShop(77602002), // Ornifex Iron King Hammer
                FreeTradeShop(77602003), // Ornifex Butcher's Knife
                FreeTradeShop(77602004), // Ornifex Spider's Silk
                FreeTradeShop(77602005), // Ornifex Spider's Fang
                FreeTradeShop(77602006), // Ornifex Thorned Greatsword
                FreeTradeShop(77602007), // Ornifex King's Mirror
                FreeTradeShop(77602008), // Ornifex Sacred Chime Hammer
                FreeTradeShop(77602009), // Ornifex Ruler's Sword
                FreeTradeShop(77602010), // Ornifex King's UGS
                FreeTradeShop(77602011), // Ornifex King's Shield
                FreeTradeShop(77602012), // Ornifex Spitfire Spear
                FreeTradeShop(77602013), // Ornifex Drakewing UGS
                FreeTradeShop(77602014), // Ornifex Curved Dragon Greatsword
                FreeTradeShop(77602015), // Ornifex Scythe of Want
                FreeTradeShop(77602016), // Ornifex Chimne of Want
                FreeTradeShop(77602017), // Ornifex Bow of Want
                FreeTradeShop(77602018), // Ornifex Defender's Greatsword
                FreeTradeShop(77602019), // Ornifex Defender's Shield
                FreeTradeShop(77602020), // Ornifex Watcher's Greatsword
                FreeTradeShop(77602021), // Ornifex Watcher's Shield

                FreeTradeShop(77602022), // Ornifex Moonlight Greatsword
                FreeTradeShop(77602023), // Ornifex Crypt Blacksword
                FreeTradeShop(77602024), // Ornifex Chaos Blade
                FreeTradeShop(77602025), // Ornifex Dragonslayer Greatbow
                FreeTradeShop(77602026), // Ornifex Yorgh's Spear
                FreeTradeShop(77602027), // Ornifex Wrathful Axe
                FreeTradeShop(77602028), // Ornifex Chime Of Screams
                FreeTradeShop(77602029), // Ornifex Fume Sword
                FreeTradeShop(77602030), // Ornifex Fume UGS
                FreeTradeShop(77602031), // Ornifex Bewitched Alonne Sword
                FreeTradeShop(77602032), // Ornifex Aged Smelter Sword
                FreeTradeShop(77602033), // Ornifex Ivory Straight Sword
                FreeTradeShop(77602034), // Ornifex Loyce Shield
                FreeTradeShop(77602035), // Ornifex Loyce Greatsword
                FreeTradeShop(77602036), // Ornifex Ivory King UGS
                FreeTradeShop(77602037), // Ornifex Eleum Loyce

                ////
                //// Copy, Keep, Remove
                TradeShopCopy(77602000, 77601000, 77601100), // Ornifex Dragonslayer Spear
                TradeShopCopy(77602001, 77601001, 77601101), // Ornifex Lost Sinner Sword
                TradeShopCopy(77602002, 77601002, 77601102), // Ornifex Iron King Hammer
                TradeShopCopy(77602003, 77601003, 77601103), // Ornifex Butcher's Knife
                TradeShopCopy(77602004, 77601004, 77601104), // Ornifex Spider's Silk
                TradeShopCopy(77602005, 77601005, 77601105), // Ornifex Spider's Fang
                TradeShopCopy(77602006, 77601006, 77601106), // Ornifex Thorned Greatsword
                TradeShopCopy(77602007, 77601007, 77601107), // Ornifex King's Mirror
                TradeShopCopy(77602008, 77601008, 77601108), // Ornifex Sacred Chime Hammer
                TradeShopCopy(77602009, 77601009, 77601109), // Ornifex Ruler's Sword
                TradeShopCopy(77602010, 77601010, 77601110), // Ornifex King's UGS
                TradeShopCopy(77602011, 77601011, 77601111), // Ornifex King's Shield
                TradeShopCopy(77602012, 77601012, 77601112), // Ornifex Spitfire Spear
                TradeShopCopy(77602013, 77601013, 77601113), // Ornifex Drakewing UGS
                TradeShopCopy(77602014, 77601014, 77601114), // Ornifex Curved Dragon Greatsword
                TradeShopCopy(77602015, 77601015, 77601115), // Ornifex Scythe of Want
                TradeShopCopy(77602016, 77601016, 77601116), // Ornifex Chimne of Want
                TradeShopCopy(77602017, 77601017, 77601117), // Ornifex Bow of Want
                TradeShopCopy(77602018, 77601018, 77601118), // Ornifex Defender's Greatsword
                TradeShopCopy(77602019, 77601019, 77601119), // Ornifex Defender's Shield
                TradeShopCopy(77602020, 77601020, 77601120), // Ornifex Watcher's Greatsword
                TradeShopCopy(77602021, 77601021, 77601121), // Ornifex Watcher's Shield

                TradeShopCopy(77602022, 77601022), // Ornifex Moonlight Greatsword
                TradeShopCopy(77602023, 77601023), // Ornifex Crypt Blacksword
                TradeShopCopy(77602024, 77601024), // Ornifex Chaos Blade
                TradeShopCopy(77602025, 77601025), // Ornifex Dragonslayer Greatbow
                TradeShopCopy(77602026, 77601026), // Ornifex Yorgh's Spear
                TradeShopCopy(77602027, 77601027), // Ornifex Wrathful Axe
                TradeShopCopy(77602028, 77601028), // Ornifex Chime Of Screams
                TradeShopCopy(77602029, 77601029), // Ornifex Fume Sword
                TradeShopCopy(77602030, 77601030), // Ornifex Fume UGS
                TradeShopCopy(77602031, 77601031), // Ornifex Bewitched Alonne Sword
                TradeShopCopy(77602032, 77601032), // Ornifex Aged Smelter Sword
                TradeShopCopy(77602033, 77601033), // Ornifex Ivory Straight Sword
                TradeShopCopy(77602034, 77601034), // Ornifex Loyce Shield
                TradeShopCopy(77602035, 77601035), // Ornifex Loyce Greatsword
                TradeShopCopy(77602036, 77601036), // Ornifex Ivory King UGS
                TradeShopCopy(77602037, 77601037), // Ornifex Eleum Loyce
                
                
            };
            return LinkedEvents;
        }

        internal static List<int> Exclusions = new List<int>()
        {
            // List of things to exclude because duplicates:
            1,              // Blank
        };
    }
    internal class LinkedShopEvent
    {
        // Setup to handle enabling/disabling of shop logic a bit more cleanly
        // Cannot do it programatically very easily because the disable events
        // can spread across all sorts of scenarios
        internal int KeepID;
        internal List<int>? RemoveIDs;
        internal bool IsTrade = false;
        internal bool FreeTrade = false;
        internal int CopyID = 0;
        internal bool IsCopy => CopyID != 0;
        internal int FillByCopy;

        internal LinkedShopEvent(int keepID, params int[] removeIDs)
        {
            KeepID = keepID;
            RemoveIDs = removeIDs.ToList();
        }
        internal LinkedShopEvent() { }
    }
}
