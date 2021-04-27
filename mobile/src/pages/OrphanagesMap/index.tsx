import React, { useState } from "react";
import { Feather } from "@expo/vector-icons";
import { StyleSheet, View, Dimensions, Text } from "react-native";
import MapView, { PROVIDER_GOOGLE, Marker, Callout } from "react-native-maps";

import mapMarker from "../../images/map-marker.png";
import { useNavigation, useFocusEffect } from "@react-navigation/native";
import { RectButton } from "react-native-gesture-handler";
import api from "../../services/api";

interface OrphanageItem {
  id: string;
  name: string;
  latitude: number;
  longitude: number;
}

const OrphanagesMap: React.FC = () => {
  const navigation = useNavigation();
  const [orphanages, setOrphanages] = useState<OrphanageItem[]>([]);
  useFocusEffect(() => {
    api.get("api/orphanages").then((response) => {
      setOrphanages(response.data);
    });
  });

  function handleNavigateToOrphanageDetail(id: string) {
    navigation.navigate("OrphanageDetails", { id });
  }
  function handleNavigateToCreateOrphanage() {
    navigation.navigate("SelectMapPosition");
  }
  return (
    <View style={styles.container}>
      <MapView
        provider={PROVIDER_GOOGLE}
        style={styles.map}
        initialRegion={{
          latitude: -15.8333611,
          longitude: -48.0335087,
          latitudeDelta: 0.0008,
          longitudeDelta: 0.0008,
        }}
      >
        {orphanages.map((orphanage) => {
          return (
            <Marker
              key={orphanage.id}
              icon={mapMarker}
              coordinate={{
                latitude: orphanage.latitude,
                longitude: orphanage.longitude,
              }}
              calloutAnchor={{
                x: 2.3,
                y: 0.7,
              }}
            >
              <Callout
                tooltip
                onPress={() => {
                  handleNavigateToOrphanageDetail(orphanage.id);
                }}
              >
                <View style={styles.calloutContainer}>
                  <Text style={styles.calloutText}>{orphanage.name}</Text>
                </View>
              </Callout>
            </Marker>
          );
        })}
      </MapView>
      <View style={styles.footer}>
        <Text style={styles.footerText}>
          {orphanages.length} orfanatos encontrados
        </Text>
        <RectButton
          style={styles.createOrphanageButton}
          onPress={handleNavigateToCreateOrphanage}
        >
          <Feather name="plus" size={20} color="#FFF" />
        </RectButton>
      </View>
    </View>
  );
};

export default OrphanagesMap;

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#fff",
    alignItems: "center",
    justifyContent: "center",
  },
  map: {
    width: Dimensions.get("window").width,
    height: Dimensions.get("window").height,
  },
  calloutContainer: {
    width: 160,
    height: 46,
    paddingHorizontal: 16,
    backgroundColor: "rgba(255,255,255,.8)",
    borderRadius: 16,
    justifyContent: "center",
  },
  calloutText: {
    color: "#0089a5",
    fontSize: 14,
    fontFamily: "Nunito_700Bold",
  },
  footer: {
    position: "absolute",
    left: 24,
    right: 24,
    bottom: 32,
    backgroundColor: "#fff",
    borderRadius: 20,
    height: 56,
    paddingLeft: 24,
    flexDirection: "row",
    justifyContent: "space-between",
    alignItems: "center",
    elevation: 3,
  },
  footerText: { fontFamily: "Nunito_700Bold", color: "#8fa7b3" },
  createOrphanageButton: {
    width: 56,
    height: 56,
    backgroundColor: "#15c3c6",
    borderRadius: 20,
    justifyContent: "center",
    alignItems: "center",
  },
});
