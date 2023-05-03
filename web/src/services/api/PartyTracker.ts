import { BaseClient } from './BaseClient';

const PartyTrackerClient = {
    getGuestInfo: async (id: string): Promise<any> => {
        return (await BaseClient.get<any>(`guest/${id}`));
    }   
}

export default PartyTrackerClient;