import { BaseClient } from './BaseClient';

const PartyTrackerClient = {
    getGuestInfo: async (id: string): Promise<IGuestInfo> => {
        return (await BaseClient.get<IGuestInfo>(`guest/${id}`));
    }   
}

export default PartyTrackerClient;