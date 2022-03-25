using System;
using System.Text;

namespace POC.Mocks
{
    public static class FileMock
    {
        private static readonly string file = "01/04/2022;98894;199;11;174;14127759,53786" + Environment.NewLine +
        "01/03/2022;102263;205;9;167;14608978,67774" + Environment.NewLine +
        "01/02/2022;99510;200;10;167;14215555,78489" + Environment.NewLine +
        "01/01/2022;89218;179;1;167;12745533,49384" + Environment.NewLine +
        "01/12/2021;79975;161;8;167;11425108,50135" + Environment.NewLine +
        "01/11/2021;86194;172;9;165;12313359,68561" + Environment.NewLine +
        "01/10/2021;67934;135;1;165;9704762,21509" + Environment.NewLine +
        "01/09/2021;76175;153;10;165;10882107,56977" + Environment.NewLine +
        "01/08/2021;62794;125;7;165;8970676,93136" + Environment.NewLine +
        "01/07/2021;72326;144;6;165;10332156,79009" + Environment.NewLine +
        "01/06/2021;61741;124;12;163;8820163,79645" + Environment.NewLine +
        "01/05/2021;57103;114;9;163;8157596,21369" + Environment.NewLine +
        "01/04/2021;62111;124;12;163;8872800,03377" + Environment.NewLine +
        "01/03/2021;56613;113;1;163;8087364,48143" + Environment.NewLine +
        "01/02/2021;57430;115;11;163;8204290,05647" + Environment.NewLine +
        "01/01/2021;45343;92;9;161;6477620,91099" + Environment.NewLine +
        "01/12/2020;52415;104;4;161;7487964,37969" + Environment.NewLine +
        "01/11/2020;47777;95;8;161;6825180,0946" + Environment.NewLine +
        "01/10/2020;41603;84;9;161;5943361,64056" + Environment.NewLine +
        "01/09/2020;37913;75;5;161;5416290,22784" + Environment.NewLine +
        "01/08/2020;35863;72;3;161;5123216,559" + Environment.NewLine +
        "01/07/2020;41616;84;9;157;5945209,00918" + Environment.NewLine +
        "01/06/2020;32584;64;11;157;4655045,70065" + Environment.NewLine +
        "01/05/2020;31185;62;9;157;4454848,41863" + Environment.NewLine +
        "01/04/2020;35636;72;3;157;5090877,53528" + Environment.NewLine +
        "01/03/2020;29804;61;12;157;4257866,83967" + Environment.NewLine +
        "01/02/2020;29244;59;8;157;4177607,66532" + Environment.NewLine +
        "01/01/2020;31438;64;11;157;4491075,39857" + Environment.NewLine +
        "01/12/2019;24873;50;3;157;3553433,6691" + Environment.NewLine +
        "01/11/2019;26747;53;5;152;3820843,07818" + Environment.NewLine +
        "01/10/2019;27018;53;5;152;3859559,84424" + Environment.NewLine +
        "01/09/2019;26211;53;5;152;3744494,0441" + Environment.NewLine +
        "01/08/2019;22427;46;11;152;3203707,64873" + Environment.NewLine +
        "01/07/2019;20701;42;11;152;2957137,46597" + Environment.NewLine +
        "01/06/2019;19792;39;12;152;2827543,77365" + Environment.NewLine +
        "01/05/2019;18945;38;4;152;2706553,50148" + Environment.NewLine +
        "01/04/2019;17316;34;6;152;2473676,76849" + Environment.NewLine +
        "01/03/2019;19933;41;2;152;2847649,81795" + Environment.NewLine +
        "01/02/2019;15648;32;7;152;2235554,59472" + Environment.NewLine +
        "01/01/2019;16572;34;6;152;2367527,19486" + Environment.NewLine +
        "01/12/2018;15114;31;5;152;2159256,91172" + Environment.NewLine +
        "01/11/2018;13690;27;11;152;1955889,42871" + Environment.NewLine +
        "01/10/2018;13771;28;3;152;1967232,47602" + Environment.NewLine +
        "01/09/2018;14994;31;5;130;2142117,46842" + Environment.NewLine +
        "01/08/2018;12848;25;2;130;1835420,5352" + Environment.NewLine +
        "01/07/2018;11329;22;0;130;1618321,22166" + Environment.NewLine +
        "01/06/2018;13122;27;11;130;1874660,33421" + Environment.NewLine +
        "01/05/2018;11038;22;0;130;1576765,76272" + Environment.NewLine +
        "01/04/2018;10311;20;11;130;1472986,92326" + Environment.NewLine +
        "01/03/2018;9465;20;11;130;1352174,28343" + Environment.NewLine +
        "01/02/2018;11000;22;0;130;1571628,92365" + Environment.NewLine +
        "01/01/2018;8625;17;12;130;1231995,40698" + Environment.NewLine +
        "01/12/2017;9019;19;2;130;1288590,2098" + Environment.NewLine +
        "01/11/2017;9232;19;2;125;1318876,51858" + Environment.NewLine +
        "01/10/2017;7549;16;3;125;1078383,74745" + Environment.NewLine +
        "01/09/2017;7380;16;3;125;1054459,60113" + Environment.NewLine +
        "01/08/2017;8163;16;3;125;1166046,69327" + Environment.NewLine +
        "01/07/2017;7878;15;8;125;1125348,54717" + Environment.NewLine +
        "01/06/2017;6581;14;12;125;940251,1609" + Environment.NewLine +
        "01/05/2017;6624;13;5;125;946255,12975" + Environment.NewLine +
        "01/04/2017;6316;12;6;125;902216,16342" + Environment.NewLine +
        "01/03/2017;6559;12;6;125;936886,79416" + Environment.NewLine +
        "01/02/2017;6139;11;12;125;876875,27236" + Environment.NewLine +
        "01/01/2017;5987;11;12;125;855117,18681" + Environment.NewLine +
        "01/12/2016;5547;11;12;125;792302,74717" + Environment.NewLine +
        "01/11/2016;5500;12;6;125;785605,30544" + Environment.NewLine +
        "01/10/2016;4879;11;12;125;697185,55363" + Environment.NewLine +
        "01/09/2016;4137;9;5;125;590953,65977" + Environment.NewLine +
        "01/08/2016;4155;9;5;125;593539,74632" + Environment.NewLine +
        "01/07/2016;4150;9;5;125;593010,86023" + Environment.NewLine +
        "01/06/2016;3792;9;5;125;541781,80072" + Environment.NewLine +
        "01/05/2016;3452;8;12;125;493188,44825" + Environment.NewLine +
        "01/04/2016;3279;6;3;125;468522,65529" + Environment.NewLine +
        "01/03/2016;3519;6;3;125;502680,75496" + Environment.NewLine +
        "01/02/2016;3513;6;3;96;501805,28585" + Environment.NewLine +
        "01/01/2016;3344;6;3;96;477566,96469" + Environment.NewLine +
        "01/12/2015;3315;7;8;96;473673,62052" + Environment.NewLine +
        "01/11/2015;2740;5;12;96;391521,25643" + Environment.NewLine +
        "01/10/2015;2956;7;8;96;422224,27169" + Environment.NewLine +
        "01/09/2015;2681;6;3;96;382809,64433" + Environment.NewLine +
        "01/08/2015;2774;7;8;96;396341,85132" + Environment.NewLine +
        "01/07/2015;2428;6;3;96;346757,58979" + Environment.NewLine +
        "01/06/2015;2501;4;9;72;357238,445" + Environment.NewLine +
        "01/05/2015;2230;4;9;72;318533,36157" + Environment.NewLine +
        "01/04/2015;2251;5;12;72;321734,48804" + Environment.NewLine +
        "01/03/2015;1910;3;2;72;272741,64673" + Environment.NewLine +
        "01/02/2015;1780;4;9;72;254285,2164" + Environment.NewLine +
        "01/01/2015;1663;4;9;72;237752,30396" + Environment.NewLine +
        "01/12/2014;1914;5;12;72;273452,18466" + Environment.NewLine +
        "01/11/2014;1650;4;9;72;235768,50911" + Environment.NewLine +
        "01/10/2014;1467;4;9;48;209624,05392" + Environment.NewLine +
        "01/09/2014;1413;2;11;48;201982,9685" + Environment.NewLine +
        "01/08/2014;1541;3;2;48;220080,19206" + Environment.NewLine +
        "01/07/2014;1304;4;9;48;186140,3426" + Environment.NewLine +
        "01/06/2014;1315;3;2;48;187799,54913" + Environment.NewLine +
        "01/05/2014;1151;2;11;46;164391,85418" + Environment.NewLine +
        "01/04/2014;1297;3;2;46;185401,68437" + Environment.NewLine +
        "01/03/2014;1087;1;10;46;155341,63042" + Environment.NewLine +
        "01/02/2014;1111;2;11;46;158815,69594" + Environment.NewLine +
        "01/01/2014;1152;3;2;25;164666,61869" + Environment.NewLine +
        "01/12/2013;917;1;10;25;130797,26855" + Environment.NewLine +
        "01/11/2013;1044;2;11;25;149037,42132" + Environment.NewLine +
        "01/10/2013;977;3;2;25;139753,22585" + Environment.NewLine +
        "01/09/2013;842;1;10;25;120414,53264" + Environment.NewLine +
        "01/08/2013;764;2;11;25;109156,32461" + Environment.NewLine +
        "01/07/2013;755;1;10;25;107805,19661" + Environment.NewLine +
        "01/06/2013;825;2;11;25;117733,66187" + Environment.NewLine +
        "01/05/2013;746;2;11;25;106633,69694" + Environment.NewLine +
        "01/04/2013;662;2;11;25;94772,73733" + Environment.NewLine +
        "01/03/2013;715;1;10;25;102237,17395" + Environment.NewLine +
        "01/02/2013;590;0;0;25;84360,54924" + Environment.NewLine +
        "01/01/2013;566;0;0;18;80775,37111" + Environment.NewLine +
        "01/12/2012;523;1;10;17;74580,62432" + Environment.NewLine +
        "01/11/2012;500;2;11;17;71549,39724" + Environment.NewLine +
        "01/10/2012;582;2;11;17;83127,55849" + Environment.NewLine +
        "01/09/2012;546;0;0;17;78108,95322" + Environment.NewLine +
        "01/08/2012;526;1;10;17;75325,54527" + Environment.NewLine +
        "01/07/2012;428;0;0;12;61084,22965" + Environment.NewLine +
        "01/06/2012;458;0;0;12;65308,59307" + Environment.NewLine +
        "01/05/2012;391;1;10;12;55992,21599" + Environment.NewLine +
        "01/04/2012;433;0;0;8;61993,11045" + Environment.NewLine +
        "01/03/2012;415;0;0;8;59161,2877" + Environment.NewLine +
        "01/02/2012;329;1;10;8;47128,12137" + Environment.NewLine
            + "01 /01/2012;350;1;10;6;50000";

        public static byte[] GetFile()
        {
            byte[] bytes = Encoding.UTF8.GetBytes(file);
            return bytes;
        }
    }
}
