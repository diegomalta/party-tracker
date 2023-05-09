import { BaseClient } from './BaseClient';

const PartyTrackerClient = {
    getGuestInfo: async (id: string): Promise<IGuestInfo> => {
        return (await BaseClient.get<IGuestInfo>(`guest/${id}`));
    },
    updateGuestInfo: async (guestInfo: IGuestInfo): Promise<any> => {
        return (await BaseClient.put(`guest/${guestInfo.id}`, guestInfo));
    }
}

export default PartyTrackerClient;