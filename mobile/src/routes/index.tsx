import React from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createStackNavigator } from "@react-navigation/stack";
import OrphanagesMap from "../pages/OrphanagesMap";
import OrphanageDetails from "../pages/OrphanageDetails";
import OrphanageData from "../pages/OrphanageData";
import SelectMapPosition from "../pages/SelectMapPosition";
import Header from "../components/Header";

const Routes: React.FC = () => {
  const { Navigator, Screen } = createStackNavigator();
  return (
    <NavigationContainer>
      <Navigator
        screenOptions={{
          headerShown: false,
          cardStyle: { backgroundColor: "#f5f2f3" },
        }}
      >
        <Screen name="OrphanagesMap" component={OrphanagesMap} />
        <Screen
          name="OrphanageDetails"
          component={OrphanageDetails}
          options={{
            headerShown: true,
            header: () => <Header showCancel={false} title="Orfanato" />,
          }}
        />
        <Screen
          name="OrphanageData"
          component={OrphanageData}
          options={{
            headerShown: true,
            header: () => <Header title="Informe os dados" />,
          }}
        />

        <Screen
          name="SelectMapPosition"
          component={SelectMapPosition}
          options={{
            headerShown: true,
            header: () => <Header title="Selecione no mapa" />,
          }}
        />
      </Navigator>
    </NavigationContainer>
  );
};

export default Routes;
