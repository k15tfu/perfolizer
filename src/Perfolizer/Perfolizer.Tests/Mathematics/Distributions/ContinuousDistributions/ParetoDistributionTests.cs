using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Perfolizer.Mathematics.Distributions.ContinuousDistributions;
using Perfolizer.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Perfolizer.Tests.Mathematics.Distributions.ContinuousDistributions;

public class ParetoDistributionTests : DistributionTestsBase
{
    public ParetoDistributionTests(ITestOutputHelper output) : base(output)
    {
    }

    private static readonly List<TestData> TestDataList = new()
    {
        new TestData(new ParetoDistribution(1, 1),
            new[]
            {
                1.5, 1.55, 1.6, 1.65, 1.7, 1.75, 1.8, 1.85, 1.9, 1.95, 2, 2.05,
                2.1, 2.15, 2.2, 2.25, 2.3, 2.35, 2.4, 2.45, 2.5, 2.55, 2.6, 2.65,
                2.7, 2.75, 2.8, 2.85, 2.9, 2.95, 3, 3.05, 3.1, 3.15, 3.2, 3.25,
                3.3, 3.35, 3.4, 3.45, 3.5, 3.55, 3.6, 3.65, 3.7, 3.75, 3.8, 3.85,
                3.9, 3.95, 4, 4.05, 4.1, 4.15, 4.2, 4.25, 4.3, 4.35, 4.4, 4.45,
                4.5, 4.55, 4.6, 4.65, 4.7, 4.75, 4.8, 4.85, 4.9, 4.95, 5, 5.05,
                5.1, 5.15, 5.2, 5.25, 5.3, 5.35, 5.4, 5.45, 5.5, 5.55, 5.6, 5.65,
                5.7, 5.75, 5.8, 5.85, 5.9, 5.95, 6, 6.05, 6.1, 6.15, 6.2, 6.25,
                6.3, 6.35, 6.4, 6.45, 6.5
            },
            new[]
            {
                0.444444444444444, 0.416233090530697, 0.390625, 0.367309458218549,
                0.346020761245675, 0.326530612244898, 0.308641975308642, 0.29218407596786,
                0.277008310249307, 0.262984878369494, 0.25, 0.237953599048186,
                0.226757369614512, 0.216333153055706, 0.206611570247934, 0.197530864197531,
                0.189035916824197, 0.181077410593029, 0.173611111111111, 0.166597251145356,
                0.16, 0.153787004998078, 0.14792899408284, 0.142399430402278,
                0.137174211248285, 0.132231404958678, 0.127551020408163, 0.123114804555248,
                0.118906064209275, 0.11490950876185, 0.111111111111111, 0.107497984412792,
                0.104058272632674, 0.100781053162006, 0.09765625, 0.0946745562130177,
                0.0918273645546373, 0.0891067052795723, 0.0865051903114187, 0.0840159630329763,
                0.0816326530612245, 0.0793493354493156, 0.0771604938271605, 0.0750609870519797,
                0.0730460189919649, 0.0711111111111111, 0.0692520775623269, 0.0674650025299376,
                0.0657462195923734, 0.0640922929017785, 0.0625, 0.060966316110349,
                0.0594883997620464, 0.0580635796196835, 0.0566893424036281, 0.055363321799308,
                0.0540832882639264, 0.0528471396485665, 0.0516528925619835, 0.0504986744097967,
                0.0493827160493827, 0.0483033450066417, 0.0472589792060492, 0.0462481211700775,
                0.0452693526482571, 0.0443213296398892, 0.0434027777777778, 0.0425124880433627,
                0.041649312786339, 0.0408121620242832, 0.04, 0.0392118419762768,
                0.0384467512495194, 0.0377038363653502, 0.0369822485207101, 0.036281179138322,
                0.0355998576005696, 0.0349375491309285, 0.0342935528120713, 0.0336671997306624,
                0.0330578512396694, 0.0324648973297622, 0.0318877551020408, 0.0313258673349518,
                0.0307787011388119, 0.0302457466918715, 0.0297265160523187, 0.0292205420410549,
                0.0287273771904625, 0.028246592754749, 0.0277777777777778, 0.0273205382146028,
                0.0268744961031981, 0.0264392887831317, 0.0260145681581686, 0.0256,
                0.0251952632905014, 0.0248000496000992, 0.0244140625, 0.0240370170061895,
                0.0236686390532544
            },
            new[]
            {
                0.333333333333333, 0.354838709677419, 0.375, 0.393939393939394,
                0.411764705882353, 0.428571428571429, 0.444444444444444, 0.45945945945946,
                0.473684210526316, 0.487179487179487, 0.5, 0.51219512195122,
                0.523809523809524, 0.534883720930233, 0.545454545454545, 0.555555555555556,
                0.565217391304348, 0.574468085106383, 0.583333333333333, 0.591836734693878,
                0.6, 0.607843137254902, 0.615384615384615, 0.622641509433962,
                0.62962962962963, 0.636363636363636, 0.642857142857143, 0.649122807017544,
                0.655172413793103, 0.661016949152542, 0.666666666666667, 0.672131147540984,
                0.67741935483871, 0.682539682539683, 0.6875, 0.692307692307692,
                0.696969696969697, 0.701492537313433, 0.705882352941177, 0.710144927536232,
                0.714285714285714, 0.71830985915493, 0.722222222222222, 0.726027397260274,
                0.72972972972973, 0.733333333333333, 0.736842105263158, 0.74025974025974,
                0.743589743589744, 0.746835443037975, 0.75, 0.753086419753086,
                0.75609756097561, 0.759036144578313, 0.761904761904762, 0.764705882352941,
                0.767441860465116, 0.770114942528736, 0.772727272727273, 0.775280898876405,
                0.777777777777778, 0.78021978021978, 0.782608695652174, 0.78494623655914,
                0.787234042553192, 0.789473684210526, 0.791666666666667, 0.793814432989691,
                0.795918367346939, 0.797979797979798, 0.8, 0.801980198019802,
                0.803921568627451, 0.805825242718447, 0.807692307692308, 0.80952380952381,
                0.811320754716981, 0.813084112149533, 0.814814814814815, 0.81651376146789,
                0.818181818181818, 0.81981981981982, 0.821428571428571, 0.823008849557522,
                0.824561403508772, 0.826086956521739, 0.827586206896552, 0.829059829059829,
                0.830508474576271, 0.831932773109244, 0.833333333333333, 0.834710743801653,
                0.836065573770492, 0.83739837398374, 0.838709677419355, 0.84,
                0.841269841269841, 0.84251968503937, 0.84375, 0.844961240310077,
                0.846153846153846
            },
            DefaultProbs,
            new[]
            {
                1, 1.01010101010101, 1.02040816326531, 1.03092783505155, 1.04166666666667,
                1.05263157894737, 1.06382978723404, 1.0752688172043, 1.08695652173913,
                1.0989010989011, 1.11111111111111, 1.12359550561798, 1.13636363636364,
                1.14942528735632, 1.16279069767442, 1.17647058823529, 1.19047619047619,
                1.20481927710843, 1.21951219512195, 1.23456790123457, 1.25, 1.26582278481013,
                1.28205128205128, 1.2987012987013, 1.31578947368421, 1.33333333333333,
                1.35135135135135, 1.36986301369863, 1.38888888888889, 1.40845070422535,
                1.42857142857143, 1.44927536231884, 1.47058823529412, 1.49253731343284,
                1.51515151515152, 1.53846153846154, 1.5625, 1.58730158730159,
                1.61290322580645, 1.63934426229508, 1.66666666666667, 1.69491525423729,
                1.72413793103448, 1.75438596491228, 1.78571428571429, 1.81818181818182,
                1.85185185185185, 1.88679245283019, 1.92307692307692, 1.96078431372549,
                2, 2.04081632653061, 2.08333333333333, 2.12765957446809, 2.17391304347826,
                2.22222222222222, 2.27272727272727, 2.32558139534884, 2.38095238095238,
                2.4390243902439, 2.5, 2.56410256410256, 2.63157894736842, 2.7027027027027,
                2.77777777777778, 2.85714285714286, 2.94117647058824, 3.03030303030303,
                3.125, 3.2258064516129, 3.33333333333333, 3.44827586206897, 3.57142857142857,
                3.7037037037037, 3.84615384615385, 4, 4.16666666666667, 4.34782608695652,
                4.54545454545455, 4.76190476190476, 5, 5.26315789473684, 5.55555555555556,
                5.88235294117647, 6.25, 6.66666666666667, 7.14285714285714, 7.69230769230769,
                8.33333333333333, 9.09090909090909, 10, 11.1111111111111, 12.5,
                14.2857142857143, 16.6666666666667, 20, 25, 33.3333333333333,
                50, 99.9999999999999,
                double.PositiveInfinity
            }),
        new TestData(new ParetoDistribution(2, 3),
            new[]
            {
                2.5, 2.55, 2.6, 2.65, 2.7, 2.75, 2.8, 2.85, 2.9, 2.95, 3, 3.05,
                3.1, 3.15, 3.2, 3.25, 3.3, 3.35, 3.4, 3.45, 3.5, 3.55, 3.6, 3.65,
                3.7, 3.75, 3.8, 3.85, 3.9, 3.95, 4, 4.05, 4.1, 4.15, 4.2, 4.25,
                4.3, 4.35, 4.4, 4.45, 4.5, 4.55, 4.6, 4.65, 4.7, 4.75, 4.8, 4.85,
                4.9, 4.95, 5, 5.05, 5.1, 5.15, 5.2, 5.25, 5.3, 5.35, 5.4, 5.45,
                5.5, 5.55, 5.6, 5.65, 5.7, 5.75, 5.8, 5.85, 5.9, 5.95, 6, 6.05,
                6.1, 6.15, 6.2, 6.25, 6.3, 6.35, 6.4, 6.45, 6.5, 6.55, 6.6, 6.65,
                6.7, 6.75, 6.8, 6.85, 6.9, 6.95, 7, 7.05, 7.1, 7.15, 7.2, 7.25,
                7.3, 7.35, 7.4, 7.45, 7.5
            },
            new[]
            {
                0.6144, 0.567610629750691, 0.525191694968663, 0.48666234669344,
                0.451602341558141, 0.419643466976299, 0.390462307371928, 0.363774122416245,
                0.339327650537764, 0.316900684893353, 0.296296296296296, 0.27733959966751,
                0.259874978479103, 0.243763696234632, 0.2288818359375, 0.215118518259165,
                0.202374357145206, 0.190560118218733, 0.179595550819554, 0.169408369064602,
                0.159933361099542, 0.151111608869952, 0.142889803383631, 0.135219642653219,
                0.128057301373788, 0.121362962962963, 0.115100405920765, 0.109236637592748,
                0.103741569376526, 0.098587728225777, 0.09375, 0.0892054008016081,
                0.084932872949977, 0.0809131026780319, 0.0771283570117389, 0.0735623376156895,
                0.0702000496665351, 0.0670276840568422, 0.0640325114404754, 0.0612027868115198,
                0.0585276634659351, 0.0559971153319358, 0.0536018667743469, 0.051333329082292,
                0.0491835429406143, 0.0471451262651453, 0.0452112268518518, 0.0433754793512895,
                0.0416319661337833, 0.0399751816583123, 0.0384, 0.0369016452281401,
                0.0354756643594182, 0.0341179026399624, 0.0328244809355415, 0.0315917750320083,
                0.03041639666834, 0.029295176142625, 0.0282251463473838, 0.0272035281049035,
                0.0262277166860187, 0.025295269407168, 0.0244038942107455, 0.0235514391428881,
                0.0227358826510153, 0.0219553246307725, 0.0212079781586102, 0.0204921618521533,
                0.0198062928058345, 0.0191488800540633, 0.0185185185185185, 0.0179138834000538,
                0.0173337249792194, 0.016776863792588, 0.016242186154944, 0.01572864,
                0.0152352310146645, 0.0147610190440171, 0.0143051147460937, 0.0138666764773403,
                0.0134449073911978, 0.0130390527337357, 0.0126483973215754, 0.012272263188553,
                0.0119100073886708, 0.0115610199438884, 0.0112247219262221, 0.0109005636644568,
                0.0105880230665376, 0.0102866040494112, 0.00999583506872137,
                0.00971526774135592, 0.00944447555437202, 0.00918305265432538,
                0.00893061271147691, 0.00868678785376675, 0.0084512276658262,
                0.00822359824864855, 0.00800358133586175, 0.00779087346284266,
                0.00758518518518519
            },
            new[]
            {
                0.488, 0.517530964711913, 0.544833864360492, 0.570114927087461,
                0.593557892597673, 0.615326821938392, 0.635568513119533, 0.654414583704568,
                0.671983271146828, 0.688380993188203, 0.703703703703704, 0.718038073671365,
                0.73146252223826, 0.744048118953637, 0.755859375, 0.766954938552572,
                0.777388207140273, 0.787207867989081, 0.796458375737838, 0.805180375575707,
                0.813411078717201, 0.821184596170556, 0.828532235939643, 0.83548276810525,
                0.842062661638995, 0.848296296296296, 0.854206152500364, 0.859812981755974,
                0.865135959810516, 0.870192824502727, 0.875, 0.879572708917829,
                0.883925073635031, 0.888070207962056, 0.892020300183565, 0.895786688377773,
                0.8993799288113, 0.902809858117579, 0.906085649887303, 0.909215866229579,
                0.912208504801097, 0.915071041746564, 0.917810470946001, 0.920433339922447,
                0.922945782726371, 0.925353550080187, 0.927662037037037, 0.929876308382082,
                0.932001121981487, 0.934040950263785, 0.936, 0.937882230532631,
                0.939691370588989, 0.941430933801398, 0.943104233045061, 0.944714393693986,
                0.946264365885933, 0.947756935878985, 0.949194736574709, 0.950580257276092,
                0.951915852742299, 0.953203751596739, 0.954446064139942, 0.955644789614227,
                0.956801822963071, 0.957918961124353, 0.958997908893354, 0.960040284388301,
                0.961047624148525, 0.962021387892774, 0.962962962962963, 0.963873668476558,
                0.964754759208921, 0.965607429225194, 0.966432815279783, 0.967232,
                0.968006014869205, 0.968755843023497, 0.969482421875, 0.970186645573718,
                0.970869367319071, 0.971531401531344, 0.972173525892534, 0.972796483265374,
                0.973400983498635, 0.973987705126251, 0.97455729696723, 0.975110379632824,
                0.975647546946963, 0.976169367285531, 0.97667638483965, 0.977169120807814,
                0.97764807452132, 0.978113724507191, 0.978566529492455, 0.979006929353397,
                0.979435346013156, 0.979852184290811, 0.980257832704874, 0.980652664233941,
                0.981037037037037
            },
            DefaultProbs,
            new[]
            {
                2, 2.00671145969597, 2.01351392344711, 2.02040957289963, 2.02740066519113,
                2.0344895363822, 2.04167860508191, 2.04897037628056, 2.05636744540385,
                2.06387250260372, 2.07148833730257, 2.07921784300884, 2.08706402242323,
                2.09502999285694, 2.10311899198444, 2.111334383956, 2.11967966589665,
                2.12815847482119, 2.13677459499708, 2.14553196579029, 2.15443469003188,
                2.16348704294728, 2.17269348169335, 2.18205865555338, 2.19158741684435,
                2.20128483259642, 2.21115619707053, 2.22120704518638, 2.23144316694056,
                2.24187062290279, 2.25249576088721, 2.26332523390627, 2.27436601952595,
                2.2856254407542, 2.29711118860897, 2.30883134652864, 2.32079441680639,
                2.33300934925067, 2.34548557229822, 2.35823302683273, 2.37126220299338,
                2.38458418029219, 2.39821067139974, 2.41215407000432, 2.42642750320259,
                2.44104488894057, 2.45602099909359, 2.47137152885499, 2.48711317319716,
                2.50326371127758, 2.51984209978975, 2.53686857640743, 2.55436477464518,
                2.5723538516627, 2.59086063078286, 2.60991176077924, 2.6295358943293,
                2.64976388843488, 2.67062903009732, 2.69216729111742, 2.71441761659491,
                2.73742225255483, 2.76122711916693, 2.78588223729465, 2.8114422176725,
                2.83796682394077, 2.86552162316636, 2.89417874047747, 2.92401773821287,
                2.95512664476325, 2.98760316437144, 3.02155610697905, 3.0571070873288,
                3.09439255574185, 3.13356624038194, 3.1748021039364, 3.21829794868543,
                3.26427984606723, 3.31300762471962, 3.36478173147995, 3.41995189335339,
                3.47892817097899, 3.5421952306087, 3.61033101195622, 3.68403149864039,
                3.76414411552411, 3.85171357110836, 3.94804606749714, 4.05480133038227,
                4.17412804484646, 4.30886938006377, 4.46288633388113, 4.64158883361278,
                4.85285500640517, 5.10872954929036, 5.42883523318982, 5.84803547642573,
                6.43659589737086, 7.36806299728077, 9.28317766722556,
                double.PositiveInfinity
            })
    };

    [UsedImplicitly]
    public static TheoryData<string> TestDataKeys = TheoryDataHelper.Create(TestDataList.Select(it => it.Distribution.ToString()!));

    [Theory]
    [MemberData(nameof(TestDataKeys))]
    public void ParetoDistributionTest(string testKey)
    {
        Check(TestDataList.First(it => it.Distribution.ToString() == testKey));
    }
}